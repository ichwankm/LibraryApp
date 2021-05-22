import React,{Component} from 'react';
import {Table} from 'react-bootstrap';

import {Button,ButtonToolbar} from 'react-bootstrap';
import {AddUserModal} from './AddUserModal';
import {EditUserModal} from './EditUserModal';

export class User extends Component{

    constructor(props){
        super(props);
        this.state={users:[], addModalShow:false, editModalShow:false}
    }

    refreshList(){
        fetch(process.env.REACT_APP_API+'User')
        .then(response=>response.json())
        .then(data=>{
            this.setState({users:data});
        });
    }

    componentDidMount(){
        this.refreshList();
    }

    componentDidUpdate(){
        this.refreshList();
    }

    deleteUser(User_ID_PK){
        if(window.confirm('Are you sure?')){
            fetch(process.env.REACT_APP_API+'User/'+User_ID_PK,{
                method:'DELETE',
                header:{'Accept':'application/json',
                        'Content-Type':'application/json'}
            })
        }
    }

    render(){
        const {users, User_ID_PK, Username, Password}=this.state;
        let addModalClose=()=>this.setState({addModalShow:false});
        let editModalClose=()=>this.setState({editModalShow:false});
        return(
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
                        {users.map(users=>
                            <tr key={users.User_ID_PK}>
                                <td>{users.User_ID_PK}</td>
                                <td>{users.Username}</td>
                                <td>
                                    <ButtonToolbar>
                                        <Button className="mr-2" variant="info"
                                                onClick={()=>this.setState({editModalShow:true,
                                                User_ID_PK:users.User_ID_PK,Username:users.Username})}>
                                                Edit
                                            </Button>

                                            <Button className="mr-2" variant="danger"
                                                onClick={()=>this.deleteUser(users.User_ID_PK)}>
                                                Delete
                                            </Button>

                                            <EditUserModal show={this.state.editModalShow}
                                            onHide={editModalClose}
                                            User_ID_PK={User_ID_PK}
                                            Username={Username}/>
                                    </ButtonToolbar>
                                </td>
                            </tr>)}
                    </tbody>
                </Table>

                <ButtonToolbar>
                    <Button variant='primary'
                    onClick={()=>this.setState({addModalShow:true})}>
                    Add User</Button>

                    <AddUserModal show={this.state.addModalShow}
                    onHide={addModalClose}/>
                </ButtonToolbar>
            </div>
        )
    }
}