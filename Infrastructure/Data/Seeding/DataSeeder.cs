/*


namespace Infrastructure.Data.Seeding
{
    public class DataSeeder(AppDbContext _context,IPasswordHasher _passwordHasher)
    {
        
        public async Task SeedAsync()
        {
          await SeedAdminAsync();
          await SeedHelpCenterAsync();
        }

        public async Task SeedAdminAsync()
        {
            var admins = new List<User>
            {
                new User {
                        Name = "Hossam Elganiny",
                        Phone="01127929624",
                        Email = "hossamelsayed676@gmail.com",
                        Password=_passwordHasher.HashPassword("123456"),
                        Role = RolesEnum.Admin,
                        CreatedAt = DateTime.UtcNow,
                        IsVerified = true,
                        Image = "Images/Users/183a074f-ecda-4032-99a4-5f978a6ca528.jpg",
                    }   
            };

            // Check if the stages already exist
            var existingAdmin = await _context.Users.Where(z => z.Role == RolesEnum.Admin).ToListAsync();

            if (!existingAdmin.Any())
            {
                foreach (var admin in admins)
                {
                    await _context.Users.AddAsync(admin);
                }

                await _context.SaveChangesAsync();
            }
        }
        public async Task SeedHelpCenterAsync()
        {
            var helpCenter = new HelpCenter
            {
                Url = "https://www.example.com"
            };

            var exist = await _context.HelpCenter.AnyAsync();
            if (!exist)
            {
                await _context.HelpCenter.AddAsync(helpCenter);
                await _context.SaveChangesAsync();
            }
        }

    }
}
*/