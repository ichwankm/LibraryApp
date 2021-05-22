import React,{Component} from 'react';
import {Modal,Button, Row, Col, Form} from 'react-bootstrap';

export class AddBookModal extends Component{
    constructor(props){
        super(props);
        this.handleSubmit=this.handleSubmit.bind(this);
    }

    handleSubmit(event){
        event.preventDefault();
        fetch(process.env.REACT_APP_API+'Book',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                Book_Name:event.target.Book_Name.value,
                Book_Price:event.target.Book_Price.value,
                Book_Amount:event.target.Book_Amount.value
            })
        })
        .then(res=>res.json())
        .then((result)=>{
            alert(result);
        },
        (error)=>{
            alert('Failed');
        })
    }
    render(){
        return (
            <div className="container">

                <Modal
                {...this.props}
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
                                <Form onSubmit={this.handleSubmit}>
                                    <Form.Group controlId="Book_Name">
                                        <Form.Label>Book Name</Form.Label>
                                        <Form.Control type="text" name="Book_Name" required 
                                        placeholder="Book Name"/>
                                    </Form.Group>

                                    <Form.Group controlId="Book_Price">
                                        <Form.Label>Book Price</Form.Label>
                                        <Form.Control type="text" name="Book_Price" required 
                                        placeholder="Book Price"/>
                                    </Form.Group>

                                    <Form.Group controlId="Book_Amount">
                                        <Form.Label>Book Amount</Form.Label>
                                        <Form.Control type="text" name="Book_Amount" required 
                                        placeholder="Book Amount"/>
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
                        <Button variant="danger" onClick={this.props.onHide}>Close</Button>
                    </Modal.Footer>

                </Modal>

            </div>
        )
    }
}