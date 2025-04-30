import React, { useState } from 'react';
import { Modal, Button, Row, Col, Form } from 'react-bootstrap';

const AddBookModal = (props) => {
    const [bookName, setBookName] = useState('');
    const [bookPrice, setBookPrice] = useState('');
    const [bookAmount, setBookAmount] = useState('');

    const handleSubmit = (event) => {
        event.preventDefault();
        fetch(`${process.env.REACT_APP_API}Book`, {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                Book_Name: bookName,
                Book_Price: bookPrice,
                Book_Amount: bookAmount,
            }),
        })
        .then((res) => res.json())
        .then(
            (result) => {
                alert(result);
            },
            (error) => {
                alert('Failed');
            }
        );
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
                        Add Book
                    </Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Row>
                        <Col sm={6}>
                            <Form onSubmit={handleSubmit}>
                                <Form.Group controlId="Book_Name">
                                    <Form.Label>Book Name</Form.Label>
                                    <Form.Control
                                        type="text"
                                        name="Book_Name"
                                        required
                                        placeholder="Book Name"
                                        value={bookName}
                                        onChange={(e) => setBookName(e.target.value)}
                                    />
                                </Form.Group>

                                <Form.Group controlId="Book_Price">
                                    <Form.Label>Book Price</Form.Label>
                                    <Form.Control
                                        type="text"
                                        name="Book_Price"
                                        required
                                        placeholder="Book Price"
                                        value={bookPrice}
                                        onChange={(e) => setBookPrice(e.target.value)}
                                    />
                                </Form.Group>

                                <Form.Group controlId="Book_Amount">
                                    <Form.Label>Book Amount</Form.Label>
                                    <Form.Control
                                        type="text"
                                        name="Book_Amount"
                                        required
                                        placeholder="Book Amount"
                                        value={bookAmount}
                                        onChange={(e) => setBookAmount(e.target.value)}
                                    />
                                </Form.Group>

                                <Form.Group>
                                    <Button variant="primary" type="submit">
                                        Add Book
                                    </Button>
                                </Form.Group>
                            </Form>
                        </Col>
                    </Row>
                </Modal.Body>

                <Modal.Footer>
                    <Button variant="danger" onClick={props.onHide}>
                        Close
                    </Button>
                </Modal.Footer>
            </Modal>
        </div>
    );
};

export default AddBookModal;