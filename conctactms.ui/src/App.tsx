import {BrowserRouter as Router, Route, Routes} from "react-router-dom";
import './App.css';
import 'react-toastify/dist/ReactToastify.css';
import Login from "./pages/auth/Login.tsx";
import Dashboard from "./pages/Dashboard.tsx";
import Contacts from "./pages/contacts/Contacts.tsx";
import Register from "./pages/auth/Register.tsx";
import AddContact from "./pages/contacts/AddContact.tsx";
import EditContact from "./pages/contacts/EditContact.tsx";

function App() {

  return (
      <Router>
          <Routes>
              <Route path="/" element={<Dashboard />}>
                  <Route path="" element={<Contacts />} />
                  <Route path="/add-contact" element={<AddContact />} />
                  <Route path="/contact/:id/edit" element={<EditContact />} />
              </Route>

              <Route path="/login" element={<Login />} />
              <Route path="/register" element={<Register />} />
          </Routes>
      </Router>
  )
}

export default App
