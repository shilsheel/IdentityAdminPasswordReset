using Microsoft.AspNetCore.Identity;

Console.WriteLine("🔐 Identity Admin Password Reset Tool");
Console.Write("Enter New Password: ");
var password = Console.ReadLine();
Console.Write("Enter Username: ");
var username = Console.ReadLine();
Console.Write("Enter Users Table Name (default: AspNetUsers): ");
var tableName = Console.ReadLine();

if (string.IsNullOrWhiteSpace(tableName))
{
    tableName = "AspNetUsers";
}

var hasher = new PasswordHasher<string>();
var hashedPassword = hasher.HashPassword(null, password);

var query = $@"
UPDATE [{tableName}]
SET 
    PasswordHash = '{hashedPassword}', 
    SecurityStamp = NEWID(),
    ConcurrencyStamp = NEWID()
WHERE UserName = '{username}';
";

Console.WriteLine("\n Password Hashed Successfully!");
Console.WriteLine($" Hashed Password: {hashedPassword}\n");
Console.WriteLine(" SQL Query:");
Console.WriteLine(query);