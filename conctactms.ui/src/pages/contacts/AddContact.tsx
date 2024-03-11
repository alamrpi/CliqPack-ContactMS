import {useForm} from "react-hook-form";
import {useNavigate} from "react-router-dom";
import {useState} from "react";
import IContactRequest from "../../contracts/contact/IContactRequest.ts";
import IContactResponse from "../../contracts/contact/IContactResponse.ts";
import {post} from "../../services/fetchFactory.ts";
import {toast} from "react-toastify";

const AddContact = () => {

    const {
        register,
        handleSubmit
    } = useForm<IContactRequest>();

    const navigate = useNavigate();
    const [isLoading, setLoading] = useState(false);

    const onSubmitHandler = async (data: IContactRequest) => {
        setLoading(true);
        const response: IContactResponse = await post("contacts", data);
        console.log(response);
        toast.success("Contact has been added");
        navigate('/');
    }

    return (
        <div className="card mt-2 me-2">
            <div className="card-body">
                <h5 className="card-title">Add Contact</h5>
                <hr/>
                <div className='row'>
                    <form onSubmit={handleSubmit(onSubmitHandler)}>
                        <div className='col-md-6 offset-3'>
                            <div className="mb-3">
                                <label htmlFor="exampleFormControlInput1" className="form-label">Name</label>
                                <input type="text" className="form-control" id='Name'
                                       {...register("name", { required: true })} />
                            </div>
                            <div className="mb-3">
                                <label htmlFor="exampleFormControlInput1" className="form-label">Email</label>
                                <input type="email" className="form-control" id='Email'
                                       {...register("email", { required: true })}/>
                            </div>

                            <div className="mb-3">
                                <label htmlFor="exampleFormControlInput1" className="form-label">Phone Number</label>
                                <input type="text" className="form-control" id='PhoneNumber'
                                       {...register("phoneNumber", { required: true })}/>
                            </div>
                            <div className="mb-3">
                                <label htmlFor="exampleFormControlTextarea1" className="form-label">Address</label>
                                <textarea className="form-control" id="address"
                                          {...register("address", { required: true })}></textarea>
                            </div>
                            <div className="mb-3 text-end">
                                <button className='btn btn-primary' disabled={isLoading}>{isLoading ? 'Loading' : 'Add'}</button>
                            </div>
                        </div>
                    </form>
                </div>

            </div>
        </div>
    );
};

export default AddContact;