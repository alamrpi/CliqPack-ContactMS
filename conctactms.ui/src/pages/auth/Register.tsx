import './Auth.css'
import {NavLink, useNavigate} from "react-router-dom";
import {useForm} from "react-hook-form";
import {post} from "../../services/fetchFactory.ts";
import ICredentialResponse from "../../contracts/auth/ICredentialResponse.ts";
import IRegisterRequest from "../../contracts/auth/IRegisterRequest.ts";
import {useState} from "react";
import {toast} from "react-toastify";

const Register = () => {

    const {
        register,
        handleSubmit,
        formState: { errors }
    } = useForm<IRegisterRequest>();

    const navigate = useNavigate();
    const [isLoading, setLoading] = useState(false);

    const onRegisterHandler = async (data: IRegisterRequest) => {

        setLoading(true);
        if(data.password !== data.confirmPassword){
            toast.warning("Password not matched!");
            setLoading(false);
            return;
        }
        const response: ICredentialResponse = await post("authentication/register", {
            name: data.name,
            email: data.email,
            password: data.password
        });
        localStorage.setItem('token', response.token);
        navigate('/');
    }

    return isLoading ? (<span>Loading</span>) : (
        <div className="row">
            <div className='col-md-6 offset-3'>
                <div className="login-form">
                    <div className="main-div">
                        <div className="panel">
                            <h2>Register</h2>
                        </div>
                        <form id="Login" onSubmit={handleSubmit(onRegisterHandler)}>
                            <div className="form-group">
                                <input type="text" className="form-control" id="name"
                                       {...register("name", { required: true })}
                                       placeholder="Full Name"/>
                                {errors.name && <span className="alert alert-danger m-2">Name field is required</span>}
                            </div>
                            <div className="form-group">
                                <input type="email" className="form-control" id="email"
                                       {...register("email", { required: true })}
                                       placeholder="Email Address"/>
                                {errors.email && <span className="alert alert-danger m-2">Email field is required</span>}
                            </div>

                            <div className="form-group">
                                <input type="password" className="form-control" id="password"
                                       {...register("password", { required: true })}
                                       placeholder="Password"/>
                                {errors.password && <span className="alert alert-danger m-2">Email field is required</span>}
                            </div>

                            <div className="form-group">
                                <input type="password" className="form-control" id="confirmPassword"
                                       {...register("confirmPassword", { required: true })}
                                       placeholder="Confirm Password"/>
                                {errors.confirmPassword && <small className="alert alert-danger m-2">Email field is required</small>}
                            </div>

                            <div className="forgot">
                                <p>Have any account? <NavLink to="/login">Login</NavLink></p>
                            </div>
                            <button type="submit" className="btn btn-primary">Register</button>

                        </form>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default Register;