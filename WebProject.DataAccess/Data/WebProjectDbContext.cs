using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebProject.Models;
using WebProject.Models.Models;

namespace WebProject.DataAccess.Data
{
    public class WebProjectDbContext : IdentityDbContext
    {
        public WebProjectDbContext(DbContextOptions<WebProjectDbContext> options) : base(options)
        {
        }

        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<ApplicationUser>? ApplicationUsers { get; set; }
        public DbSet<ShoppingCart>? ShoppingCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Harry Potter",
                    Author = "J. K. Rowling",
                    Description = "Harry Potter has never been the star of a Quidditch team, scoring points while riding a broom far above the ground. He knows no spells, has never helped to hatch a dragon, and has never worn a cloak of invisibility.All he knows is a miserable life with the Dursleys, his horrible aunt and uncle, and their abominable son, Dudley - a great big swollen spoiled bully. Harry's room is a tiny closet at the foot of the stairs, and he hasn't had a birthday party in eleven years.But all that is about to change when a mysterious letter arrives by owl messenger: a letter with an invitation to an incredible place that Harry - and anyone who reads about him - will find unforgettable.For it's there that he finds not only friends, aerial sports, and magic in everything from classes to meals, but a great destiny that's been waiting for him... if Harry can survive the encounter.",
                    Isbn = "9780590353427",
                    ListPrice = 10.99,
                    Price = 10.22,
                    Price50 = 10.09,
                    Price100 = 9.69,
                    CategoryId = 2,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 2,
                    Title = "The Hunger Games",
                    Author = "Suzanne Collins",
                    Description = "The first novel in the worldwide bestselling series by Suzanne Collin! Winning means fame and fortune. Losing means certain death. The Hunger Games have begun. . . . In the ruins of a place once known as North America lies the nation of Panem, a shining Capitol surrounded by twelve outlying districts. The Capitol is harsh and cruel and keeps the districts in line by forcing them all to send one boy and one girl between the ages of twelve and eighteen to participate in the annual Hunger Games, a fight to the death on live TV. Sixteen-year-old Katniss Everdeen regards it as a death sentence when she steps forward to take her sister's place in the Games. But Katniss has been close to dead before-and survival, for her, is second nature. Without really meaning to, she becomes a contender. But if she is to win, she will have to start making choices that weigh survival against humanity and life against love.",
                    Isbn = "9780439023528",
                    ListPrice = 14.99,
                    Price = 13.94,
                    Price50 = 13.49,
                    Price100 = 13.09,
                    CategoryId = 1,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 3,
                    Title = "Twilight",
                    Author = "Stephenie Meyer",
                    Description = "Fall in love with the addictive, suspenseful love story between a teenage girl and a vampire with the book that sparked a 'literary phenomenon' and redefined romance for a generation (New York Times). Isabella Swan's move to Forks, a small, perpetually rainy town in Washington, could have been the most boring move she ever made. But once she meets the mysterious and alluring Edward Cullen, Isabella's life takes a thrilling and terrifying turn. Up until now, Edward has managed to keep his vampire identity a secret in the small community he lives in, but now nobody is safe, especially Isabella, the person Edward holds most dear. The lovers find themselves balanced precariously on the point of a knife -- between desire and danger. Deeply romantic and extraordinarily suspenseful, Twilight captures the struggle between defying our instincts and satisfying our desires. This is a love story with bite. It's here! #1 bestselling author Stephenie Meyer makes a triumphant return to the world of Twilight with the highly anticipated companion, Midnight Sun: the iconic love story of Bella and Edward told from the vampire's point of view.",
                    Isbn = "9780316160179",
                    ListPrice = 24.99,
                    Price = 23.24,
                    Price50 = 22.89,
                    Price100 = 22.49,
                    CategoryId = 1,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 4,
                    Title = "The Hobbit",
                    Author = "J. R. R. Tolkien",
                    Description = "The journey through Middle-earth begins here with J.R.R. Tolkien's classic prelude to his Lord of the Rings trilogy.\r\n\r\n\"A glorious account of a magnificent adventure, filled with suspense and seasoned with a quiet humor that is irresistible... All those, young or old, who love a fine adventurous tale, beautifully told, will take The Hobbit to their hearts.\"--The New York Times Book Review\r\n\r\n\"In a hole in the ground there lived a hobbit.\" So begins one of the most beloved and delightful tales in the English language--Tolkien's prelude to The Lord of the Rings. Set in the imaginary world of Middle-earth, at once a classic myth and a modern fairy tale, The Hobbit is one of literature's most enduring and well-loved novels.\r\n\r\nBilbo Baggins is a hobbit who enjoys a comfortable, unambitious life, rarely traveling any farther than his pantry or cellar. But his contentment is disturbed when the wizard Gandalf and a company of dwarves arrive on his doorstep one day to whisk him away on an adventure. They have launched a plot to raid the treasure hoard guarded by Smaug the Magnificent, a large and very dangerous dragon. Bilbo reluctantly joins their quest, unaware that on his journey to the Lonely Mountain he will encounter both a magic ring and a frightening creature known as Gollum.",
                    Isbn = "9780743493564",
                    ListPrice = 17.99,
                    Price = 16.73,
                    Price50 = 15.89,
                    Price100 = 15.10,
                    CategoryId = 2,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 6,
                    Title = "Angels & Demons",
                    Author = "Dan Brown",
                    Description = "The explosive Robert Langdon thriller from Dan Brown, the #1 New York Times bestselling author of The Da Vinci Code and Inferno--now a major film directed by Ron Howard and starring Tom Hanks and Felicity Jones.An ancient secret brotherhood. A devastating new weapon of destruction. An unthinkable target. When world-renowned Harvard symbologist Robert Langdon is summoned to his first assignment to a Swiss research facility to analyze a mysterious symbol--seared into the chest of a murdered physicist--he discovers evidence of the unimaginable: the resurgence of an ancient secret brotherhood known as the Illuminati...the most powerful underground organization ever to walk the earth. The Illuminati has now surfaced to carry out the final phase of its legendary vendetta against its most hated enemy--the Catholic Church. Langdon's worst fears are confirmed on the eve of the Vatican's holy conclave, when a messenger of the Illuminati announces they have hidden an unstoppable time bomb at the very heart of Vatican City. With the countdown under way, Langdon jets to Rome to join forces with Vittoria Vetra, a beautiful and mysterious Italian scientist, to assist the Vatican in a desperate bid for survival. Embarking on a frantic hunt through sealed crypts, dangerous catacombs, deserted cathedrals, and the most secretive vault on earth, Langdon and Vetra follow a 400-year-old trail of ancient symbols that snakes across Rome toward the long-forgotten Illuminati lair...a clandestine location that contains the only hope for Vatican salvation. Critics have praised the exhilarating blend of relentless adventure, scholarly intrigue, and cutting wit found in Brown's remarkable thrillers featuring Robert Langdon. An explosive international suspense, Angels & Demons marks this hero's first adventure as it careens from enlightening epiphanies to dark truths as the battle between science and religion turns to war.",
                    Isbn = "9780743493468",
                    ListPrice = 18.99,
                    Price = 17.66,
                    Price50 = 16.70,
                    Price100 = 15.99,
                    CategoryId = 3,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 5,
                    Title = "The Great Gatsby",
                    Author = "F. Scott Fitzgerald",
                    Description = "The only authorized edition of the twentieth-century classic, featuring F. Scott Fitzgerald's final revisions, a foreword by his granddaughter, and a new introduction by National Book Award winner Jesmyn Ward. Nominated as one of America's best-loved novels by PBS's The Great American Read. The Great Gatsby, F. Scott Fitzgerald's third book, stands as the supreme achievement of his career. First published in 1925, this quintessential novel of the Jazz Age has been acclaimed by generations of readers. The story of the mysteriously wealthy Jay Gatsby and his love for the beautiful Daisy Buchanan, of lavish parties on Long Island at a time when The New York Times noted 'gin was the national drink and sex the national obsession,' it is an exquisitely crafted tale of America in the 1920s.",
                    Isbn = "9780743273565",
                    ListPrice = 17.00,
                    Price = 15.81,
                    Price50 = 14.89,
                    Price100 = 14.09,
                    CategoryId = 3,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 7,
                    Title = "1984",
                    Author = "George Orwell",
                    Description = "The beloved, #1 global bestseller by John Green, author of The Anthropocene Reviewed and Turtles All the Way Down 'John Green is one of the best writers alive.' -E. Lockhart, #1 bestselling author of We Were Liars 'The greatest romance story of this decade.' -Entertainment Weekly #1 New York Times Bestseller - #1 Wall reet Journal Bestseller - #1 USA Today Bestseller - #1 International Bestseller Despite the tumor-shrinking medical miracle that has bought her a few years, Hazel has never been anything but terminal, her final chapter inscribed upon diagnosis. But when a gorgeous plot twist named Augustus Waters suddenly appears at Cancer Kid Support Group, Hazel's story is about to be completely rewritten. From John Green, #1 bestselling author of The Anthropocene Reviewed and Turtles All the Way Down, The Fault in Our Stars is insightful, bold, irreverent, and raw. It brilliantly explores the funny, thrilling, and tragic business of being alive and in love.",
                    Isbn = "9780451524935",
                    ListPrice = 9.99,
                    Price = 9.29,
                    Price50 = 8.79,
                    Price100 = 8.09,
                    CategoryId = 3,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 8,
                    Title = "Pride and Prejudice",
                    Author = "Jane Austen",
                    Description = "Austen's most popular novel, the unforgettable story of Elizabeth Bennet and Mr. Darcy Few have failed to be charmed by the witty and independent spirit of Elizabeth Bennet in Austen's beloved classic Pride and Prejudice. When Elizabeth Bennet first meets eligible bachelor Fitzwilliam Darcy, she thinks him arrogant and conceited; he is indifferent to her good looks and lively mind. When she later discovers that Darcy has involved himself in the troubled relationship between his friend Bingley and her beloved sister Jane, she is determined to dislike him more than ever. In the sparkling comedy of manners that follows, Jane Austen shows us the folly of judging by first impressions and superbly evokes the friendships, gossip and snobberies of provincial middle-class life. This Penguin Classics edition, based on Austen's first edition, contains the original Penguin Classics introduction by Tony Tanner and an updated introduction and notes by Viven Jones. For more than seventy years, Penguin has been the leading publisher of classic literature in the English-speaking world. With more than 1,700 titles, Penguin Classics represents a global bookshelf of the best works throughout history and across genres and disciplines. Readers trust the series to provide authoritative texts enhanced by introductions and notes by distinguished scholars and contemporary authors, as well as up-to-date translations by award-winning translators.",
                    Isbn = "9780141439518",
                    ListPrice = 9.00,
                    Price = 8.37,
                    Price50 = 7.99,
                    Price100 = 7.50,
                    CategoryId = 3,
                    ImageUrl = ""
                });
        }
    }
}