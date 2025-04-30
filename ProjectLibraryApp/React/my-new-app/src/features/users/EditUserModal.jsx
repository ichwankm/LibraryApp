import React from 'react';
import { Modal, Button, Row, Col, Form } from 'react-bootstrap';

const EditUserModal = ({ show, onHide, User_ID_PK, Username }) => {
    const handleSubmit = (event) => {
        event.preventDefault();
        fetch(process.env.REACT_APP_API + 'User', {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                User_ID_PK: event.target.User_ID_PK.value,
                Username: event.target.Username.value,
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
        <Modal show={show} onHide={onHide} size="lg" aria-labelledby="contained-modal-title-vcenter" centered>
            <Modal.Header closeButton>
                <Modal.Title id="contained-modal-title-vcenter">Edit User</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Row>
                    <Col sm={6}>
                        <Form onSubmit={handleSubmit}>
                            <Form.Group controlId="User_ID_PK">
                                <Form.Label>User ID</Form.Label>
                                <Form.Control
                                    type="text"
                                    name="User_ID_PK"
                                    required
                                    disabled
                                    defaultValue={User_ID_PK}
                                    placeholder="User ID"
                                />
                            </Form.Group>

                            <Form.Group controlId="Username">
                                <Form.Label>Username</Form.Label>
                                <Form.Control
                                    type="text"
                                    name="Username"
                                    required
                                    defaultValue={Username}
                                    placeholder="Username"
                                />
                            </Form.Group>

                            <Form.Group>
                                <Button variant="primary" type="submit">
                                    Update User
                                </Button>
                            </Form.Group>
                        </Form>
                    </Col>
                </Row>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="danger" onClick={onHide}>
                    Close
                </Button>
            </Modal.Footer>
        </Modal>
    );
};

export default EditUserModal;