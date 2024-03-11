import {NavLink} from "react-router-dom";
import {useEffect, useState} from "react";
import IContactResponse from "../../contracts/contact/IContactResponse.ts";
import {del, get} from "../../services/fetchFactory.ts";

const Contacts = () => {
    const [isLoading, setLoading] = useState(true);
    const [contacts, setContacts] = useState<IContactResponse[]>([]);

    const [searchTerm, setSearchTerm] = useState('')
    useEffect( () => {
        loadContacts();
    }, []);

    const loadContacts = async () => {
        let url = '/contacts';
        if(searchTerm !== ''){
            url += '?searchterm='+searchTerm;
        }
        const response: IContactResponse[] = await get(url);
        setContacts(response);
        setLoading(false);
    }

    const searchHandler = async () => {
        setLoading(true);
        await loadContacts();
    }

    const deleteHandler = async (id: string) => {
        await del(`/contacts/${id}`);
        await loadContacts();
    }

    return isLoading ? (<span>Page Loading</span>) : (
        <div className="card mt-2 me-2">
            <div className="card-body">
                <h5 className="card-title">Contacts</h5>
                <hr/>

                <div className='row'>
                    <div className='col-md-6'>
                        <form>
                            <div className="input-group mb-3">
                                <input type="text" className="form-control" value={searchTerm} onChange={(input) => setSearchTerm(input.target.value)} placeholder="Search"/>
                                <button className='btn btn-sm btn-info' type='button' onClick={searchHandler}>Search</button>
                            </div>
                        </form>
                    </div>

                    <div className='col-md-6 text-end'>
                        <NavLink to='/add-contact' className='btn btn-sm btn-primary'>Add Contact</NavLink>
                    </div>

                    <div className='col-md-12'>
                    <div className='table-responsive'>
                            <table className='table table-sm table-bordered'>
                                <thead>
                                <tr>
                                    <th className='text-center'>#</th>
                                    <th>Name</th>
                                    <th>Email</th>
                                    <th>Phone</th>
                                    <th>Address</th>
                                    <th className='text-center'>Action</th>
                                </tr>
                                </thead>
                                <tbody>
                                {contacts.map(({id, name, email, phoneNumber, address}, index) => (
                                    <tr key={index}>
                                        <td className='text-center'>{index + 1}</td>
                                        <td>{name}</td>
                                        <td>{email}</td>
                                        <td>{phoneNumber}</td>
                                        <td>{address}</td>
                                        <td className='text-center'>
                                            <NavLink className='btn btn-info btn-sm' to={`/contact/${id}/edit`}>Edit</NavLink>
                                            <button className='btn btn-danger btn-sm' type='button' onClick={() => deleteHandler(id)}>Delete</button>
                                        </td>
                                    </tr>
                                ))}

                                </tbody>
                            </table>
                    </div>
                    </div>
                </div>

            </div>
        </div>
    );
};

export default Contacts;