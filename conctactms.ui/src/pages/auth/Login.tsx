import './Auth.css'
import {NavLink, useNavigate} from "react-router-dom";
import {post} from "../../services/fetchFactory.ts";
import { useForm } from 'react-hook-form';
import ICredentialResponse from "../../contracts/auth/ICredentialResponse.ts";
import ILoginRequest from "../../contracts/auth/ILoginRequest.ts";
import {useEffect} from "react";

const Login = () => {

    const { register, handleSubmit } = useForm<ILoginRequest>();

    const navigate = useNavigate()


    const loginHandler = async (data: ILoginRequest) => {

        const response: ICredentialResponse = await post("authentication/login", {
            email: data.userName,
            password: data.password
        });
        localStorage.setItem('token', response.token);
        navigate('/');
    }

    useEffect(() => {
        const token = localStorage.getItem('token');
        if(token)
            navigate('/');
    })


    return (
        <div className="row">
            <div className='col-md-6 offset-3'>
                <div className="login-form">
                    <div className="main-div">
                        <div className="panel">
                            <h2>Login</h2>
                            <p>Please enter your email and password</p>
                        </div>
                        <form id="Login" onSubmit={handleSubmit(loginHandler)}>
                            <div className="form-group">
                                <input type="email" className="form-control"  id="userName"
                                       {...register("userName", { required: true })}
                                       placeholder="Email Address"/>
                            </div>

                            <div className="form-group">
                                <input type="password" className="form-control" id="password"
                                       {...register("password", { required: true })}
                                       placeholder="Password"/>

                            </div>
                            <div className="forgot">
                                <p>Don't have any account? <NavLink to="/register">Register</NavLink></p>
                            </div>
                            <button type="submit" className="btn btn-primary">Login</button>

                        </form>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default Login;