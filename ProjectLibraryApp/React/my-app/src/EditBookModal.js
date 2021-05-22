import React,{Component} from 'react';
import {Modal,Button, Row, Col, Form} from 'react-bootstrap';

export class EditBookModal extends Component{
    constructor(props){
        super(props);
        this.handleSubmit=this.handleSubmit.bind(this);
    }

    handleSubmit(event){
        event.preventDefault();
        fetch(process.env.REACT_APP_API+'Book',{
            method:'PUT',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                Book_ID_PK:event.target.Book_ID_PK.value,
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
                            Edit Book
                        </Modal.Title>
                    </Modal.Header>
                    <Modal.Body>

                        <Row>
                            <Col sm={6}>
                                <Form onSubmit={this.handleSubmit}>
                                <Form.Group controlId="Book_ID_PK">
                                        <Form.Label>Book ID</Form.Label>
                                        <Form.Control type="text" name="Book_ID_PK" required
                                        disabled
                                        defaultValue={this.props.Book_ID_PK} 
                                        placeholder="Book ID"/>
                                    </Form.Group>

                                    <Form.Group controlId="Book_Name">
                                        <Form.Label>Book Name</Form.Label>
                                        <Form.Control type="text" name="Book_Name" required
                                        defaultValue={this.props.Book_Name}  
                                        placeholder="Book Name"/>
                                    </Form.Group>

                                    <Form.Group controlId="Book_Price">
                                        <Form.Label>Book Price</Form.Label>
                                        <Form.Control type="text" name="Book_Price" required
                                        defaultValue={this.props.Book_Price}  
                                        placeholder="Book Price"/>
                                    </Form.Group>

                                    <Form.Group controlId="Book_Amount">
                                        <Form.Label>Book Amount</Form.Label>
                                        <Form.Control type="text" name="Book_Amount" required
                                        defaultValue={this.props.Book_Amount}  
                                        placeholder="Book Amount"/>
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
                        <Button variant="danger" onClick={this.props.onHide}>Close</Button>
                    </Modal.Footer>

                </Modal>

            </div>
        )
    }

}