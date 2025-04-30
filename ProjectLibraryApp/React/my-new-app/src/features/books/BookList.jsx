import React, { useState, useEffect } from 'react';
import { Table, Button, ButtonToolbar } from 'react-bootstrap';
import AddBookModal from './AddBookModal';
import EditBookModal from './EditBookModal';

export const BookList = () => {
    const [books, setBooks] = useState([]);
    const [addModalShow, setAddModalShow] = useState(false);
    const [editModalShow, setEditModalShow] = useState(false);
    const [selectedBook, setSelectedBook] = useState(null);

    const refreshList = () => {
        fetch('https://localhost:7119/api/' + 'Book')
            .then((response) => response.json())
            .then((data) => {
                setBooks(data);
            });
    };

    useEffect(() => {
        refreshList();
    }, []);

    const deleteBook = (Book_ID_PK) => {
        if (window.confirm('Are you sure?')) {
            fetch('https://localhost:7119/api/' + 'Book/' + Book_ID_PK, {
                method: 'DELETE',
                headers: {
                    Accept: 'application/json',
                    'Content-Type': 'application/json',
                },
            }).then(() => refreshList());
        }
    };

    return (
        <div>
            <Table className="mt-4" striped bordered hover size="sm">
                <thead>
                    <tr>
                        <th>Book ID</th>
                        <th>Book Name</th>
                        <th>Book Price</th>
                        <th>Book Amount</th>
                        <th>Options</th>
                    </tr>
                </thead>
                <tbody>
                    {books.map((book) => (
                        <tr key={book.id}>
                            <td>{book.id}</td>
                            <td>{book.name}</td>
                            <td>{book.price}</td>
                            <td>{book.amount}</td>
                            <td>
                                <ButtonToolbar>
                                    <Button
                                        className="mr-2"
                                        variant="info"
                                        onClick={() => {
                                            setSelectedBook(book);
                                            setEditModalShow(true);
                                        }}
                                    >
                                        Edit
                                    </Button>

                                    <Button
                                        className="mr-2"
                                        variant="danger"
                                        onClick={() => deleteBook(book.Book_ID_PK)}
                                    >
                                        Delete
                                    </Button>
                                </ButtonToolbar>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>

            <ButtonToolbar>
                <Button variant="primary" onClick={() => setAddModalShow(true)}>
                    Add Book
                </Button>
            </ButtonToolbar>

            <AddBookModal show={addModalShow} onHide={() => setAddModalShow(false)} />
            {selectedBook && (
                <EditBookModal
                    show={editModalShow}
                    onHide={() => setEditModalShow(false)}
                    Book_ID_PK={selectedBook.Book_ID_PK}
                    Book_Name={selectedBook.Book_Name}
                    Book_Price={selectedBook.Book_Price}
                    Book_Amount={selectedBook.Book_Amount}
                />
            )}
        </div>
    );
};