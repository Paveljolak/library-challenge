-- Insert Authors
INSERT INTO library_db.authors (id, name, dateofbirth)
VALUES
    (1, 'J.K. Rowling', '1965-07-31'),
    (2, 'George R.R. Martin', '1948-09-20'),
    (3, 'J.R.R. Tolkien', '1892-01-03'),
    (4, 'Agatha Christie', '1890-09-15'),
    (5, 'Stephen King', '1947-09-21'),
    (6, 'Isaac Asimov', '1920-01-02'),
    (7, 'Ray Bradbury', '1920-08-22'),
    (8, 'H.G. Wells', '1866-09-21'),
    (9, 'Arthur C. Clarke', '1917-12-16'),
    (10, 'Margaret Atwood', '1939-11-18');


INSERT INTO library_db.books (title, publicationyear, authorid)
VALUES
    -- J.K. Rowling's Books
    ('Harry Potter and the Sorcerers Stone', 1997, 1),
    ('Harry Potter and the Chamber of Secrets', 1998, 1),
    ('Harry Potter and the Prisoner of Azkaban', 1999, 1),
    ('Harry Potter and the Goblet of Fire', 2000, 1),
    ('Harry Potter and the Order of the Phoenix', 2003, 1),
    -- George R.R. Martin's Books
    ('A Game of Thrones', 1996, 2),
    ('A Clash of Kings', 1998, 2),
    ('A Storm of Swords', 2000, 2),
    ('A Feast for Crows', 2005, 2),
    ('A Dance with Dragons', 2011, 2),
    -- J.R.R. Tolkien's Books
    ('The Hobbit', 1937, 3),
    ('The Fellowship of the Ring', 1954, 3),
    ('The Two Towers', 1954, 3),
    ('The Return of the King', 1955, 3),
    ('The Silmarillion', 1977, 3),
    -- Agatha Christie's Books
    ('Murder on the Orient Express', 1934, 4),
    ('The Murder of Roger Ackroyd', 1926, 4),
    ('And Then There Were None', 1939, 4),
    ('Death on the Nile', 1937, 4),
    ('The ABC Murders', 1936, 4),
    -- Stephen King's Books
    ('The Shining', 1977, 5),
    ('It', 1986, 5),
    ('Carrie', 1974, 5),
    ('Misery', 1987, 5),
    -- Ray Bradbury's Books
    ('Fahrenheit 451', 1953, 7),
    ('The Martian Chronicles', 1950, 7),
    ('Something Wicked This Way Comes', 1962, 7),
    ('Dandelion Wine', 1957, 7),
    ('The Illustrated Man', 1951, 7),
    -- H.G. Wells' Books
    ('The War of the Worlds', 1898, 8),
    ('The Time Machine', 1895, 8),
    ('The Invisible Man', 1897, 8),
    ('The Island of Doctor Moreau', 1896, 8),
    ('The First Men in the Moon', 1901, 8),
    -- Arthur C. Clarke's Books
    ('2001: A Space Odyssey', 1968, 9),
    ('Rendezvous with Rama', 1973, 9),
    ('Childhoods End', 1953, 9),
    ('The Fountains of Paradise', 1979, 9),
    ('The City and the Stars', 1956, 9),
    -- Margaret Atwood's Books
    ('The Handmaids Tale', 1985, 10),
    ('Oryx and Crake', 2003, 10),
    ('The Year of the Flood', 2009, 10),
    ('Alias Grace', 1996, 10),
    ('The Blind Assassin', 2000, 10);
    
