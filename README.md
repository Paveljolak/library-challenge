# Library Management System - Dinit d.o.o Challenge

## Tech Stack

- PostgreSQL (+pg_trgm)
- .NET 8 (+FuzzySharp )
- React

## Starting Environment
### Database
For the database this project uses PostgreSQL local database.
I am providing the backup file(database_backup.sql) for my local database, run this in the pg4admin sql query, 
and it will recreate the database. 

Note: you will first have to create a schema with the name "library_db".
Next you can run the examples from the example.sql to add some dummy data into the database.
Copy the examples and run them into a query into pg4admin. It might not let you run the two queries together so try running then one by one.
Add the authors first, then add the books.


Clone the repo to your own local directory of choice.
Open the project with your favourite IDE, or through terminal.

### Backend:
Once inside the project run: "cd libraryChallenge/"

This will bring you into the libraryChallenge directory.

Next run: "dotnet run"

This should run your backend. Alternatively you can use Rider or Visual Studio, to open and run the backend.

Don't forget to connect to the database through your IDE.

### Frontend:
Open the project in a new terminal, or open it in VSCode.

In the terminal run: "cd frontend/"

Now you entered the frontend part of the project.

Next run: npm start

If you follow the link in the output given by the terminal, you will see the application. If everything is set up correctly
you will see the list of books.


## Testing
### Backend
In the backend files (libraryChallenge/ directory) you can find **Author.http** and **Book.http** files. In these files we have the endpoints we use in our api.
They can be run and tested, individually.

### Frontend
Well, click through it :D 

## Similarity Search
The similarity search in this challenge is implemented in two steps. It uses both **database-level fuzzy search** 
and **in-memory fuzzy matching.**

### Required libraries
- run this command to postgresql:
 **CREATE EXTENSION IF NOT EXISTS pg_trgm;**

- run this command in the terminal:
  **dotnet add package FuzzySharp**

### Explanation
When a client searches for a book by title, the system performs.

1. **PostgreSQL similarity search** (using `pg_trgm` extenstion)
2. **In-memory fuzzy filtering** (using `FuzzySharp` library)

It is a hybrid approach to balance performance:
- The **database** narrows down the search to 200(hardcoded value) likely matches.
- The **in-memory** layer ranks and filters those based on more precise fuzzy logic.

#### Database search
We use PostgreSQL's `pg_trgm` extension and the `similarity()` function to get titles similar to the user's input.
The query pulls up to 200 books from the database that meet a minimum similarity threshold.

We do this so we limit the in-memory search, so we don't have to pull all of the book records. 


#### In-Memory filter
After receiving those 200 books from the DB, we run a second layer of filtering using FuzzySharp library.
This library computes a similarity score (0 to 100) between the input and each book title.
Only the results with a score above 30 will be included and results will be given back in descending order of similarity.

#### Final output
The final output will be given based on the specified maxResults by the client. If we want the top 10 searches we put maxResults = 10.
If we want top 5 similar titles we put maxResults = 5. 

### Endpoint:
We test the logic with the next endpoint:

GET \[api\]books/search?title=\[SomeTitle\]&maxResults=5

Where we switch \[api\] with the actual api we are using in our case it is local so we use:
http://localhost:5000/

and we switch \[SomeTitle\] with the actual title we want to search for.

Example of full api:
GET http://localhost:5000/books/search?title=Harry%20Potter&maxResults=5

This will search for the title: `Harry Potter` and will return maximum of 5 results.


## Pagination
The application uses pagination, and the maximum books per page is set to be 10. 
The books component pulls one extra page for the next page for the pagination on the front-end. So at 
one time we fetch only 20 books. Sadly, I did not test how well it will hold against huge amount of books like 100 000.

## Caching the authors
The data for the authors is fetched only once at the start of the application and is stored on the client as a state. Then from this 
state we use the authors data, without having to refetch it everytime we open the forms for adding or editing a book.

## Unit tests
No time sorry.

### TODO:
Here is are the things I did not manage to fix due to time constraints:
- In posting and updating the books, we can choose the author that does not exist. This should not be possible. Of course this has a 
quick fix on the front-end since we have a menu to choose from authors, but it should be fixed in the backend as well. 
- Adding endpoints for testing data validation in the .http files.
- Unit Tests.
- Test how well the application works with a lot of records.
