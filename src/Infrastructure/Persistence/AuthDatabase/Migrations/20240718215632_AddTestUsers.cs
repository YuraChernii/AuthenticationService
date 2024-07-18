using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.AuthDatabase.Migrations
{
    public partial class AddTestUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO Users (Id, UserName, FirstName, LastName, Email, Password, Gender, LastLoginTime, CreatedOn, ModifiedOn, IsDeleted)
                VALUES 
                (NEWID(), 'user1', 'John', 'Doe', 'john.doe1@example.com', 'XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=', 0, GETDATE(), GETDATE(), GETDATE(), 0),
                (NEWID(), 'user2', 'Jane', 'Doe', 'jane.doe2@example.com', 'XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=', 1, GETDATE(), GETDATE(), GETDATE(), 0),
                (NEWID(), 'user3', 'Alice', 'Smith', 'alice.smith3@example.com', 'XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=', 1, GETDATE(), GETDATE(), GETDATE(), 0),
                (NEWID(), 'user4', 'Bob', 'Smith', 'bob.smith4@example.com', 'XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=', 0, GETDATE(), GETDATE(), GETDATE(), 0),
                (NEWID(), 'user5', 'Charlie', 'Brown', 'charlie.brown5@example.com', 'XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=', 0, GETDATE(), GETDATE(), GETDATE(), 0),
                (NEWID(), 'user6', 'David', 'Wilson', 'david.wilson6@example.com', 'XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=', 0, GETDATE(), GETDATE(), GETDATE(), 0),
                (NEWID(), 'user7', 'Eve', 'Johnson', 'eve.johnson7@example.com', 'XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=', 1, GETDATE(), GETDATE(), GETDATE(), 0),
                (NEWID(), 'user8', 'Frank', 'Williams', 'frank.williams8@example.com', 'XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=', 0, GETDATE(), GETDATE(), GETDATE(), 0),
                (NEWID(), 'user9', 'Grace', 'Jones', 'grace.jones9@example.com', 'XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=', 1, GETDATE(), GETDATE(), GETDATE(), 0),
                (NEWID(), 'user10', 'Hank', 'Brown', 'hank.brown10@example.com', 'XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=', 0, GETDATE(), GETDATE(), GETDATE(), 0),
                (NEWID(), 'user11', 'Ivy', 'Davis', 'ivy.davis11@example.com', 'XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=', 1, GETDATE(), GETDATE(), GETDATE(), 0),
                (NEWID(), 'user12', 'Jack', 'Garcia', 'jack.garcia12@example.com', 'XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=', 0, GETDATE(), GETDATE(), GETDATE(), 0),
                (NEWID(), 'user13', 'Kelly', 'Martinez', 'kelly.martinez13@example.com', 'XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=', 1, GETDATE(), GETDATE(), GETDATE(), 0),
                (NEWID(), 'user14', 'Larry', 'Rodriguez', 'larry.rodriguez14@example.com', 'XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=', 0, GETDATE(), GETDATE(), GETDATE(), 0),
                (NEWID(), 'user15', 'Mandy', 'Hernandez', 'mandy.hernandez15@example.com', 'XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=', 1, GETDATE(), GETDATE(), GETDATE(), 0),
                (NEWID(), 'user16', 'Nick', 'Lopez', 'nick.lopez16@example.com', 'XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=', 0, GETDATE(), GETDATE(), GETDATE(), 0),
                (NEWID(), 'user17', 'Olivia', 'Gonzales', 'olivia.gonzales17@example.com', 'XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=', 1, GETDATE(), GETDATE(), GETDATE(), 0),
                (NEWID(), 'user18', 'Paul', 'Wilson', 'paul.wilson18@example.com', 'XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=', 0, GETDATE(), GETDATE(), GETDATE(), 0),
                (NEWID(), 'user19', 'Quincy', 'Anderson', 'quincy.anderson19@example.com', 'XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=', 0, GETDATE(), GETDATE(), GETDATE(), 0),
                (NEWID(), 'user20', 'Rachel', 'Thomas', 'rachel.thomas20@example.com', 'XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=', 1, GETDATE(), GETDATE(), GETDATE(), 0);
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DELETE FROM Users
                WHERE UserName IN (
                    'user1', 'user2', 'user3', 'user4', 'user5', 'user6', 'user7', 'user8', 'user9', 'user10', 
                    'user11', 'user12', 'user13', 'user14', 'user15', 'user16', 'user17', 'user18', 'user19', 'user20'
                );
            ");
        }
    }
}