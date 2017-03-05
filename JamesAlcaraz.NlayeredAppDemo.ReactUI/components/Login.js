import React from 'react';
import axios from 'axios';
import {Card} from './Card';

const baseUrl = 'http://localhost:58010';

export class Login extends React.Component {
    constructor() {
        super();
        this.state = {
            email: '',
            password: ''
        };
    }
    
    handleEmailChange(event) {
        this.setState({email: event.target.value});
    }
    
    handlePasswordChange(event) {
        this.setState({password: event.target.value});
    }

    handleSubmit(event) {
        event.preventDefault();

        //TODO: polyfill for IE for URLSearchParams
        var params = new URLSearchParams();
        params.append('grant_type', 'password');
        params.append('username', this.state.email);
        params.append('password', this.state.password);

        //Post via application/x-www-form-urlencoded
        axios.post(baseUrl + '/token', params).then((response) => {
                console.log(response);
            }).catch( error => {
                console.log(error);
            }); 
        
    }
    componentDidMount() {

    }

    render() {
        
        return(
            <Card cardHeader = {"Login"}>
                <form role="form">
                    <div className="form-group fg-line">
                        <label htmlFor="exampleInputEmail1">Email address</label>
                        <input type="email" className="form-control input-sm" id="exampleInputEmail1"
                                placeholder="Enter email" value = {this.setState.email} onChange = {this.handleEmailChange.bind(this)}/>
                    </div>
                    <div className="form-group fg-line">
                        <label htmlFor="exampleInputPassword1">Password</label>
                        <input type="password" className="form-control input-sm" id="exampleInputPassword1"
                                placeholder="Password" value = {this.setState.password} onChange = {this.handlePasswordChange.bind(this)}/>
                    </div>
                    <div className="checkbox">
                        <label>
                            <input type="checkbox" value="" />
                            <i className="input-helper"></i>
                            Don't forget to check me out
                        </label>
                    </div>

                    <button type="submit" className="btn btn-primary btn-sm m-t-10" onClick = {this.handleSubmit.bind(this)}>Submit</button>
                </form> 
            </Card>

        );
            
    }
}