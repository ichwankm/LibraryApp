import React,{Component} from 'react';
import {Table} from 'react-bootstrap';

import {Button,ButtonToolbar} from 'react-bootstrap';
import {AddBookModal} from './AddBookModal';
import {EditBookModal} from './EditBookModal';

export class Book extends Component{

    constructor(props){
        super(props);
        this.state={books:[], addModalShow:false, editModalShow:false}
    }

    refreshList(){
        fetch(process.env.REACT_APP_API+'Book')
        .then(response=>response.json())
        .then(data=>{
            this.setState({books:data});
        });
    }

    componentDidMount(){
        this.refreshList();
    }

    componentDidUpdate(){
        this.refreshList();
    }

    deleteBook(Book_ID_PK){
        if(window.confirm('Are you sure?')){
            fetch(process.env.REACT_APP_API+'Book/'+Book_ID_PK,{
                method:'DELETE',
                header:{'Accept':'application/json',
            'Content-Type':'application/json'}
            })
        }
    }

    render(){
        const {books, Book_ID_PK, Book_Name, Book_Price, Book_Amount}=this.state;
        let addModalClose=()=>this.setState({addModalShow:false});
        let editModalClose=()=>this.setState({editModalShow:false});
        return(
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
                        {books.map(books=>
                            <tr key={books.Book_ID_PK}>
                                <td>{books.Book_ID_PK}</td>
                                <td>{books.Book_Name}</td>
                                <td>{books.Book_Price}</td>
                                <td>{books.Book_Amount}</td>
                                <td>
                                    <ButtonToolbar>
                                        <Button className="mr-2" variant="info"
                                                onClick={()=>this.setState({editModalShow:true,
                                                Book_ID_PK:books.Book_ID_PK,Book_Name:books.Book_Name,Book_Price:books.Book_Price,Book_Amount:books.Book_Amount})}>
                                                Edit
                                            </Button>

                                            <Button className="mr-2" variant="danger"
                                                onClick={()=>this.deleteBook(books.Book_ID_PK)}>
                                                Delete
                                            </Button>

                                            <EditBookModal show={this.state.editModalShow}
                                            onHide={editModalClose}
                                            Book_ID_PK={Book_ID_PK}
                                            Book_Name={Book_Name}
                                            Book_Price={Book_Price}
                                            Book_Amount={Book_Amount}/>
                                    </ButtonToolbar>
                                </td>
                            </tr>)}
                    </tbody>
                </Table>

                <ButtonToolbar>
                    <Button variant='primary'
                    onClick={()=>this.setState({addModalShow:true})}>
                    Add Book</Button>

                    <AddBookModal show={this.state.addModalShow}
                    onHide={addModalClose}/>
                </ButtonToolbar>
            </div>
        )
    }
}