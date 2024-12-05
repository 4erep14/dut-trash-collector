-- Create table in PostgreSQL syntax
CREATE TABLE books (
                       id SERIAL PRIMARY KEY,
                       title VARCHAR(100) NOT NULL,
                       author VARCHAR(100) NOT NULL,
                       genre VARCHAR(50),
                       pages INT,
                       publication_year INT,
                       is_available BOOLEAN DEFAULT TRUE
);

-- Adding new column
ALTER TABLE books ADD COLUMN isbn VARCHAR(20);

-- Insert data
INSERT INTO books (title, author, publication_year, genre, isbn, pages) VALUES
                                                                            ('The Great Gatsby', 'F. Scott Fitzgerald', 1925, 'Fiction', '9780743273565', 180),
                                                                            ('Moby Dick', 'Herman Melville', 1851, 'Adventure', '9780142437247', 635),
                                                                            ('War and Peace', 'Leo Tolstoy', 1869, 'Historical', '9780199232765', 1225);

-- 1. Select books of a particular genre
SELECT * FROM books WHERE genre = 'Fiction';

-- 2. Update the number of pages for a book
UPDATE books SET pages = 200 WHERE title = 'The Great Gatsby';

-- 3. Select books by a particular author
SELECT * FROM books WHERE author = 'Leo Tolstoy';


-- Create procedure to add a new book
CREATE OR REPLACE PROCEDURE AddBook(
    p_title VARCHAR(100),
    p_author VARCHAR(100),
    p_publication_year INT,
    p_genre VARCHAR(50),
    p_isbn VARCHAR(20),
    p_pages INT
)
    LANGUAGE plpgsql
AS $$
BEGIN
    INSERT INTO books (title, author, publication_year, genre, isbn, pages)
    VALUES (p_title, p_author, p_publication_year, p_genre, p_isbn, p_pages);
END;
$$;

-- Call the procedure to add a new book
CALL AddBook('Don Quixote', 'Miguel de Cervantes', 1605, 'Adventure', '9780060934347', 992);
