import React, { useState, useEffect } from 'react';
import { Modal, Button, Row, Col, Form } from 'react-bootstrap';

const AddTransactionModal = (props) => {
    const [books, setBooks] = useState([]);
    const [users, setUsers] = useState([]);

    useEffect(() => {
        fetch(process.env.REACT_APP_API + 'Book')
            .then(response => response.json())
            .then(data => setBooks(data));

        fetch(process.env.REACT_APP_API + 'User')
            .then(response => response.json())
            .then(data => setUsers(data));
    }, []);

    const handleSubmit = (event) => {
        event.preventDefault();
        fetch(process.env.REACT_APP_API + 'Transaction', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                Book_ID_FK: event.target.Book_Name.value,
                User_ID_FK: event.target.Username.value,
                Borrow_Date: event.target.Borrow_Date.value,
                Return_Date: event.target.Return_Date.value
            })
        })
            .then(res => res.json())
            .then((result) => {
                alert(result);
            }, (error) => {
                alert('Failed');
            });
    };

    return (
        <div className="container">
            <Modal
                {...props}
                size="lg"
                aria-labelledby="contained-modal-title-vcenter"
                centered
            >
                <Modal.Header closeButton>
                    <Modal.Title id="contained-modal-title-vcenter">
                        Add Transaction
                    </Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Row>
                        <Col sm={6}>
                            <Form onSubmit={handleSubmit}>
                                <Form.Group controlId="Book_Name">
                                    <Form.Label>Book Name</Form.Label>
                                    <Form.Control as="select">
                                        {books.map(book =>
                                            <option key={book.Book_ID_PK} value={book.Book_ID_PK}>{book.Book_Name}</option>
                                        )}
                                    </Form.Control>
                                </Form.Group>

                                <Form.Group controlId="Username">
                                    <Form.Label>Username</Form.Label>
                                    <Form.Control as="select">
                                        {users.map(user =>
                                            <option key={user.User_ID_PK} value={user.User_ID_PK}>{user.Username}</option>
                                        )}
                                    </Form.Control>
                                </Form.Group>

                                <Form.Group controlId="Borrow_Date">
                                    <Form.Label>Borrow Date</Form.Label>
                                    <Form.Control
                                        type="date"
                                        name="Borrow_Date"
                                        required
                                        placeholder="Borrow_Date"
                                    />
                                </Form.Group>

                                <Form.Group controlId="Return_Date">
                                    <Form.Label>Return Date</Form.Label>
                                    <Form.Control
                                        type="date"
                                        name="Return_Date"
                                        required
                                        placeholder="Return_Date"
                                    />
                                </Form.Group>

                                <Form.Group>
                                    <Button variant="primary" type="submit">
                                        Add Transaction
                                    </Button>
                                </Form.Group>
                            </Form>
                        </Col>
                    </Row>
                </Modal.Body>

                <Modal.Footer>
                    <Button variant="danger" onClick={props.onHide}>Close</Button>
                </Modal.Footer>
            </Modal>
        </div>
    );
};

export default AddTransactionModal;