import DashboardLayout from "../components/shared/DashboardLayout.tsx";
import {Outlet, useNavigate} from "react-router-dom";
import {useEffect} from "react";
import {ToastContainer} from "react-toastify";


const Dashboard = () => {
    const navigate = useNavigate();
    useEffect(() => {
        const token = localStorage.getItem('token');
        if(token === null){
            navigate('/login');
        }
    }, [navigate])

    return (
        <DashboardLayout>
            <Outlet/>
            <ToastContainer/>
        </DashboardLayout>
    );
};

export default Dashboard;