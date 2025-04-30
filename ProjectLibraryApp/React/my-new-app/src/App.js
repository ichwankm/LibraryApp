import { BrowserRouter, Routes, Route } from 'react-router-dom';
import './App.css';
import Home from './features/home/Home';
import { Book } from './features/books/Book';
import { User } from './features/users/User';
import { Transaction } from './features/transactions/Transaction';
import Navigation from './components/Navigation';

function App() {
  return (
    <BrowserRouter>
      <div className="container">
        <h3 className="m-3 d-flex justify-content-center">Library Apps</h3>
        <Navigation />

        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/Book" element={<Book />} />
          <Route path="/User" element={<User />} />
          <Route path="/Transaction" element={<Transaction />} />
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;