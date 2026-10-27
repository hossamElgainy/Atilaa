using Core.Interfaces.IServices.SystemIServices;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Application.Services.SystemServices
{
    public class FileService : IFileService
    {
        private readonly ILogger<FileService> _logger;
        private readonly string _webRootPath;

        // Separate allowed extensions
        private readonly string[] _imageExtensions = { ".jpg", ".jpeg", ".png" };
        private readonly string[] _pdfExtensions = { ".pdf" };

        // Separate MIME types
        private readonly string[] _imageMimeTypes = { "image/jpg", "image/jpeg", "image/png" };
        private readonly string[] _pdfMimeTypes = { "application/pdf" };

        public FileService(ILogger<FileService> logger, string webRootPath)
        {
            _logger = logger;
            _webRootPath = webRootPath ?? throw new ArgumentNullException(nameof(webRootPath));

            // Ensure base Images directory exists
            var imagesPath = Path.Combine(_webRootPath, "Images");
            Directory.CreateDirectory(imagesPath);
        }

        public async Task<string> UploadFileAsync(IFormFile file, string folderName)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("No file uploaded");

            var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();

            // === 1. Separate Extension Check ===
            bool isImage = _imageExtensions.Contains(fileExtension);
            bool isPdf = _pdfExtensions.Contains(fileExtension);

            if (!isImage && !isPdf)
            {
                throw new ArgumentException("Only .jpg, .jpeg, .png, and .pdf files are allowed.");
            }

            // === 2. Dynamic File Size Validation ===
            long maxSizeInBytes = isPdf ? 10 * 1024 * 1024 : 5 * 1024 * 1024; // 10MB for PDF, 5MB for images

            if (file.Length > maxSizeInBytes)
            {
                var maxSizeMB = maxSizeInBytes / (1024 * 1024);
                throw new ArgumentException($"File size must be less than {maxSizeMB} MB.");
            }

            // === 3. Separate MIME Type Validation ===
            var contentType = file.ContentType.ToLowerInvariant();

            bool isValidMimeType = (isImage && _imageMimeTypes.Contains(contentType)) ||
                                   (isPdf && _pdfMimeTypes.Contains(contentType));

            if (!isValidMimeType)
            {
                throw new ArgumentException("Invalid file type. Only JPG, JPEG, PNG, and PDF files are allowed.");
            }

            // Sanitize folder name
            var safeFolderName = Path.GetFileName(folderName);
            if (string.IsNullOrWhiteSpace(safeFolderName))
                throw new ArgumentException("Invalid folder name");

            // Create target directory inside Images/
            var uploadsPath = Path.Combine(_webRootPath, "Images", safeFolderName);
            Directory.CreateDirectory(uploadsPath);

            // Generate unique filename
            var uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";
            var fullPath = Path.Combine(uploadsPath, uniqueFileName);

            // Save file
            try
            {
                await using var fileStream = new FileStream(fullPath, FileMode.Create);
                await file.CopyToAsync(fileStream);

                // Return relative path
                var relativePath = Path.Combine("Images", safeFolderName, uniqueFileName).Replace("\\", "/");
                return relativePath;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error uploading file to {Path}", fullPath);
                throw new ApplicationException("File upload failed", ex);
            }
        }

        public async Task<List<string>> UploadListOfFilesAsync(List<IFormFile>? files,string folderName)
        {
            var savedPaths = new List<string>();

            if (files == null || files.Count == 0)
            {
                return savedPaths;  // empty list = no files uploaded
            }

            // Sanitize folder name (same as your code)
            var safeFolderName = Path.GetFileName(folderName);
            if (string.IsNullOrWhiteSpace(safeFolderName))
            {
                throw new ArgumentException("Invalid folder name");
            }

            // Prepare directory once (outside the loop)
            var uploadsPath = Path.Combine(_webRootPath, "Images", safeFolderName);
            Directory.CreateDirectory(uploadsPath);

            foreach (var file in files)
            {
                if (file == null || file.Length == 0)
                    continue;

                var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();

                // You can add extension validation here if you want (optional)
                // var allowed = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp", ".pdf" };
                // if (!allowed.Contains(fileExtension)) continue;

                var uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";
                var fullPath = Path.Combine(uploadsPath, uniqueFileName);

                try
                {
                    await using var fileStream = new FileStream(fullPath, FileMode.Create);
                    await file.CopyToAsync(fileStream);

                    var relativePath = Path.Combine("Images", safeFolderName, uniqueFileName)
                                             .Replace("\\", "/");

                    savedPaths.Add(relativePath);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error uploading file to {Path}", fullPath);
                    // Option A: continue to next file (recommended in batch upload)
                    // Option B: throw → stops everything if one file fails
                    // throw new ApplicationException($"Failed to upload {file.FileName}", ex);
                }
            }

            return savedPaths;
        }

        public async Task DeleteFileAsync(string fileName, string folderName)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("File name is required");

            if (string.IsNullOrWhiteSpace(folderName))
                throw new ArgumentException("Folder name is required");

            // Sanitize folder name (same as upload method)
            var safeFolderName = Path.GetFileName(folderName);
            if (string.IsNullOrWhiteSpace(safeFolderName))
                throw new ArgumentException("Invalid folder name");

            // Sanitize file name to prevent path traversal attacks
            var safeFileName = Path.GetFileName(fileName);
            if (string.IsNullOrWhiteSpace(safeFileName))
                throw new ArgumentException("Invalid file name");

            // Construct the full path (same structure as upload method)
            var fullPath = Path.Combine(_webRootPath, "Images", safeFolderName, safeFileName);

            // Check if file exists
            if (!File.Exists(fullPath))
            {
                _logger.LogWarning("File not found: {Path}", fullPath);
                return;
            }

            try
            {
                await Task.Run(() => File.Delete(fullPath));
                _logger.LogInformation("Deleted file: {Path}", fullPath);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting file: {Path}", fullPath);
                throw;
            }
        }

    }
}