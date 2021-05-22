import React,{Component} from 'react';
import {Table} from 'react-bootstrap';

import {Button,ButtonToolbar} from 'react-bootstrap';
import {AddTransactionModal} from './AddTransactionModal';

export class Transaction extends Component{

    constructor(props){
        super(props);
        this.state={transactions:[], addModalShow:false, editModalShow:false}
    }

    refreshList(){
        fetch(process.env.REACT_APP_API+'Transaction')
        .then(response=>response.json())
        .then(data=>{
            this.setState({transactions:data});
        });
    }

    componentDidMount(){
        this.refreshList();
    }

    componentDidUpdate(){
        this.refreshList();
    }

    updateTransaction(ID){
        if(window.confirm('Are you sure?')){
            fetch(process.env.REACT_APP_API+'Transaction',{
                method:'PUT',
                headers:{
                    'Accept':'application/json',
                    'Content-Type':'application/json'
                },
                body:JSON.stringify({
                    Transaction_ID_PK: ID
                })
            })
            .then(res=>res.json())
            .then((result)=>{
                alert(result);
                this.refreshList();
            },
            (error)=>{
                alert('Failed');
            })
        }
    }

    render(){
        const {transactions}=this.state;
        let addModalClose=()=>this.setState({addModalShow:false});
        return(
            <div>
                <Table className="mt-4" striped bordered hover size="sm">
                    <thead>
                        <tr>
                        <th>Transaction ID</th>
                        <th>Book Name</th>
                        <th>Book Price</th>
                        <th>Username</th>
                        <th>Borrow Date</th>
                        <th>Return Date</th>
                        <th>Transaction Done</th>
                        <th>Options</th>
                        </tr>
                    </thead>
                    <tbody>
                        {transactions.map(transactions=>
                            <tr key={transactions.Transaction_ID_PK}>
                                <td>{transactions.Transaction_ID_PK}</td>
                                <td>{transactions.Book_Name}</td>
                                <td>{transactions.Book_Price}</td>
                                <td>{transactions.Username}</td>
                                <td>{transactions.Borrow_Date}</td>
                                <td>{transactions.Return_Date}</td>
                                <td>{transactions.IsDoneBorrow}</td>
                                <td>
                                    <ButtonToolbar>
                                            <Button className="mr-2" variant="danger"
                                                onClick={()=>this.updateTransaction(transactions.Transaction_ID_PK)}>
                                                Done Borrow
                                            </Button>
                                    </ButtonToolbar>
                                </td>
                            </tr>)}
                    </tbody>
                </Table>

                <ButtonToolbar>
                    <Button variant='primary'
                    onClick={()=>this.setState({addModalShow:true})}>
                    Add Transaction</Button>

                    <AddTransactionModal show={this.state.addModalShow}
                    onHide={addModalClose}/>
                </ButtonToolbar>
            </div>
        )
    }
}