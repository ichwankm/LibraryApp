import React, { useState } from 'react';
import { Modal, Button, Row, Col, Form } from 'react-bootstrap';

const EditBookModal = (props) => {
    const [bookDetails, setBookDetails] = useState({
        Book_ID_PK: props.Book_ID_PK || '',
        Book_Name: props.Book_Name || '',
        Book_Price: props.Book_Price || '',
        Book_Amount: props.Book_Amount || ''
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setBookDetails({ ...bookDetails, [name]: value });
    };

    const handleSubmit = (event) => {
        event.preventDefault();
        fetch(process.env.REACT_APP_API + 'Book', {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(bookDetails)
        })
        .then(res => res.json())
        .then((result) => {
            alert(result);
        },
        (error) => {
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
                        Edit Book
                    </Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Row>
                        <Col sm={6}>
                            <Form onSubmit={handleSubmit}>
                                <Form.Group controlId="Book_ID_PK">
                                    <Form.Label>Book ID</Form.Label>
                                    <Form.Control
                                        type="text"
                                        name="Book_ID_PK"
                                        required
                                        disabled
                                        value={bookDetails.Book_ID_PK}
                                        placeholder="Book ID"
                                    />
                                </Form.Group>

                                <Form.Group controlId="Book_Name">
                                    <Form.Label>Book Name</Form.Label>
                                    <Form.Control
                                        type="text"
                                        name="Book_Name"
                                        required
                                        value={bookDetails.Book_Name}
                                        onChange={handleChange}
                                        placeholder="Book Name"
                                    />
                                </Form.Group>

                                <Form.Group controlId="Book_Price">
                                    <Form.Label>Book Price</Form.Label>
                                    <Form.Control
                                        type="text"
                                        name="Book_Price"
                                        required
                                        value={bookDetails.Book_Price}
                                        onChange={handleChange}
                                        placeholder="Book Price"
                                    />
                                </Form.Group>

                                <Form.Group controlId="Book_Amount">
                                    <Form.Label>Book Amount</Form.Label>
                                    <Form.Control
                                        type="text"
                                        name="Book_Amount"
                                        required
                                        value={bookDetails.Book_Amount}
                                        onChange={handleChange}
                                        placeholder="Book Amount"
                                    />
                                </Form.Group>

                                <Form.Group>
                                    <Button variant="primary" type="submit">
                                        Update Book
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

export default EditBookModal;