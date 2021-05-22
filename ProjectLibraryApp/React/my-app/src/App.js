import logo from './logo.svg';
import './App.css';

import {Home} from './Home'
import {Book} from './Book'
import {User} from './User'
import {Transaction} from './Transaction'
import {Navigation} from './Navigation'

import {BrowserRouter, Route, Switch} from 'react-router-dom';

function App() {
  return (
    <BrowserRouter>
    <div className="container">
     <h3 className="m-3 d-flex justify-content-center">
       Library Apps
     </h3>

     <Navigation/>

     <Switch>
       <Route path='/' component={Home} exact/>
       <Route path='/Book' component={Book}/>
       <Route path='/User' component={User}/>
       <Route path='/Transaction' component={Transaction}/>
     </Switch>
    </div>
    </BrowserRouter>
  );
}

export default App;
