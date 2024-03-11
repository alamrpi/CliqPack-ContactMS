import { ReactNode } from 'react';
import {NavLink, useNavigate} from "react-router-dom";

const DashboardLayout = ({ children }: { children: ReactNode }) => {

    const navigate = useNavigate();
    const logOutHandler = () => {
        localStorage.removeItem('token');
        navigate('/login');
    }

    return (
        <div className='row'>
            <div className='col-md-3'>
                <div className="d-flex flex-column flex-shrink-0 p-3 bg-body-tertiary">
                    <a href="/"
                       className="d-flex align-items-center mb-3 mb-md-0 me-md-auto link-body-emphasis text-decoration-none">
                        <span className="fs-4">Contact Management</span>
                    </a>
                    <hr/>
                    <ul className="nav nav-pills flex-column mb-auto">
                        <li className="nav-item">
                            <NavLink to="/" className="nav-link active">
                                Contact
                            </NavLink>
                        </li>
                        <li className="nav-item">
                            <button onClick={logOutHandler} className="nav-link">
                                Logout
                            </button>
                        </li>
                    </ul>
                </div>
            </div>
            <div className='col-md-9'>
                {children}
            </div>
        </div>
    );
};

export default DashboardLayout;