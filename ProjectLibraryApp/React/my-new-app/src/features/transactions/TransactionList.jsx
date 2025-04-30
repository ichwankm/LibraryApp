import React, { useState, useEffect } from 'react';
import { Table, Button, ButtonToolbar } from 'react-bootstrap';
import AddTransactionModal from './AddTransactionModal';

const TransactionList = () => {
    const [transactions, setTransactions] = useState([]);
    const [addModalShow, setAddModalShow] = useState(false);

    const refreshList = () => {
        fetch(process.env.REACT_APP_API + 'Transaction')
            .then(response => response.json())
            .then(data => {
                setTransactions(data);
            })
            .catch(error => {
                console.error('Error fetching transactions:', error);
            });
    };

    useEffect(() => {
        refreshList();
    }, []);

    const updateTransaction = (ID) => {
        if (window.confirm('Are you sure?')) {
            fetch(process.env.REACT_APP_API + 'Transaction', {
                method: 'PUT',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    Transaction_ID_PK: ID
                })
            })
                .then(res => res.json())
                .then((result) => {
                    alert(result);
                    refreshList();
                })
                .catch(() => {
                    alert('Failed');
                });
        }
    };

    return (
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
                    {transactions.map(transaction => (
                        <tr key={transaction.Transaction_ID_PK}>
                            <td>{transaction.Transaction_ID_PK}</td>
                            <td>{transaction.Book_Name}</td>
                            <td>{transaction.Book_Price}</td>
                            <td>{transaction.Username}</td>
                            <td>{transaction.Borrow_Date}</td>
                            <td>{transaction.Return_Date}</td>
                            <td>{transaction.IsDoneBorrow}</td>
                            <td>
                                <ButtonToolbar>
                                    <Button
                                        className="mr-2"
                                        variant="danger"
                                        onClick={() => updateTransaction(transaction.Transaction_ID_PK)}
                                    >
                                        Done Borrow
                                    </Button>
                                </ButtonToolbar>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>

            <ButtonToolbar>
                <Button variant="primary" onClick={() => setAddModalShow(true)}>
                    Add Transaction
                </Button>

                <AddTransactionModal
                    show={addModalShow}
                    onHide={() => setAddModalShow(false)}
                />
            </ButtonToolbar>
        </div>
    );
};

export default TransactionList;