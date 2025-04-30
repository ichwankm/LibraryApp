import React, { useState, useEffect } from 'react';
import { Table, Button, ButtonToolbar } from 'react-bootstrap';
import AddUserModal from './AddUserModal';
import EditUserModal from './EditUserModal';

export const UserList = () => {
    const [users, setUsers] = useState([]);
    const [addModalShow, setAddModalShow] = useState(false);
    const [editModalShow, setEditModalShow] = useState(false);
    const [selectedUser, setSelectedUser] = useState({ User_ID_PK: null, Username: '' });

    const refreshList = () => {
        fetch(process.env.REACT_APP_API + 'User')
            .then(response => response.json())
            .then(data => setUsers(data));
    };

    useEffect(() => {
        refreshList();
    }, []);

    const deleteUser = (User_ID_PK) => {
        if (window.confirm('Are you sure?')) {
            fetch(process.env.REACT_APP_API + 'User/' + User_ID_PK, {
                method: 'DELETE',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                }
            }).then(() => refreshList());
        }
    };

    return (
        <div>
            <Table className="mt-4" striped bordered hover size="sm">
                <thead>
                    <tr>
                        <th>User ID</th>
                        <th>Username</th>
                        <th>Options</th>
                    </tr>
                </thead>
                <tbody>
                    {users.map(user => (
                        <tr key={user.User_ID_PK}>
                            <td>{user.User_ID_PK}</td>
                            <td>{user.Username}</td>
                            <td>
                                <ButtonToolbar>
                                    <Button
                                        className="mr-2"
                                        variant="info"
                                        onClick={() => {
                                            setEditModalShow(true);
                                            setSelectedUser({ User_ID_PK: user.User_ID_PK, Username: user.Username });
                                        }}
                                    >
                                        Edit
                                    </Button>

                                    <Button
                                        className="mr-2"
                                        variant="danger"
                                        onClick={() => deleteUser(user.User_ID_PK)}
                                    >
                                        Delete
                                    </Button>

                                    <EditUserModal
                                        show={editModalShow}
                                        onHide={() => setEditModalShow(false)}
                                        User_ID_PK={selectedUser.User_ID_PK}
                                        Username={selectedUser.Username}
                                    />
                                </ButtonToolbar>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>

            <ButtonToolbar>
                <Button variant="primary" onClick={() => setAddModalShow(true)}>
                    Add User
                </Button>

                <AddUserModal show={addModalShow} onHide={() => setAddModalShow(false)} />
            </ButtonToolbar>
        </div>
    );
};