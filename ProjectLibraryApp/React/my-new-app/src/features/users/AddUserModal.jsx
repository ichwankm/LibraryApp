import React, { useState } from 'react';
import { Modal, Button, Row, Col, Form } from 'react-bootstrap';

const AddUserModal = (props) => {
    const [username, setUsername] = useState('');

    const handleSubmit = (event) => {
        event.preventDefault();
        fetch(`${process.env.REACT_APP_API}User`, {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                Username: username,
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
                        Add User
                    </Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Row>
                        <Col sm={6}>
                            <Form onSubmit={handleSubmit}>
                                <Form.Group controlId="Username">
                                    <Form.Label>Username</Form.Label>
                                    <Form.Control
                                        type="text"
                                        name="Username"
                                        required
                                        placeholder="Username"
                                        value={username}
                                        onChange={(e) => setUsername(e.target.value)}
                                    />
                                </Form.Group>

                                <Form.Group>
                                    <Button variant="primary" type="submit">
                                        Add User
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

export default AddUserModal;