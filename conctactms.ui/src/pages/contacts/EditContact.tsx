import {useForm} from "react-hook-form";
import {useNavigate, useParams} from "react-router-dom";
import {useEffect, useState} from "react";
import IContactRequest from "../../contracts/contact/IContactRequest.ts";
import IContactResponse from "../../contracts/contact/IContactResponse.ts";
import {get, put} from "../../services/fetchFactory.ts";
import {toast} from "react-toastify";

const AddContact = () => {

    const {
        register,
        handleSubmit
    } = useForm<IContactRequest>();

    const navigate = useNavigate();
    const [isLoading, setLoading] = useState(true);
    const [contact, setContact] = useState<IContactResponse>()
    const params = useParams();
    const onSubmitHandler = async (data: IContactRequest) => {
        setLoading(true);
        await put(`contacts/${params.id}`, data);
        toast.success("Contact has been updated");
        navigate('/');
    }

    const loadContact = async () => {
        const response: IContactResponse = await get(`contacts/${params.id}`);
        setContact(response);
        setLoading(false);
    }

    useEffect(() => {
        loadContact();
    }, [])

    return isLoading ? (<span>Loading...</span>) : (
        <div className="card mt-2 me-2">
            <div className="card-body">
                <h5 className="card-title">Update Contact</h5>
                <hr/>
                <div className='row'>
                    <form onSubmit={handleSubmit(onSubmitHandler)}>
                        <div className='col-md-6 offset-3'>
                            <div className="mb-3">
                                <label htmlFor="exampleFormControlInput1" className="form-label">Name</label>
                                <input type="text" className="form-control" id='Name' defaultValue={contact?.name}
                                       {...register("name", { required: true })} />
                            </div>
                            <div className="mb-3">
                                <label htmlFor="exampleFormControlInput1" className="form-label">Email</label>
                                <input type="email" className="form-control" id='Email' defaultValue={contact?.email}
                                       {...register("email", { required: true })}/>
                            </div>

                            <div className="mb-3">
                                <label htmlFor="exampleFormControlInput1" className="form-label">Phone Number</label>
                                <input type="text" className="form-control" id='PhoneNumber' defaultValue={contact?.phoneNumber}
                                       {...register("phoneNumber", { required: true })}/>
                            </div>
                            <div className="mb-3">
                                <label htmlFor="exampleFormControlTextarea1" className="form-label">Address</label>
                                <textarea className="form-control" id="address" defaultValue={contact?.address}
                                          {...register("address", { required: true })}></textarea>
                            </div>
                            <div className="mb-3 text-end">
                                <button className='btn btn-primary' disabled={isLoading}>{isLoading ? 'Loading' : 'Update'}</button>
                            </div>
                        </div>
                    </form>
                </div>

            </div>
        </div>
    );
};

export default AddContact;