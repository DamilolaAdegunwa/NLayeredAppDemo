import React from 'react';
import axios from 'axios';

const baseUrl = 'http://localhost:58010';

export class ProductList extends React.Component {
    constructor() {
        super();
        this.state ={
            UserName: "John"
        }
    }
    
    componentDidMount() {
        axios.get(baseUrl + '/api/products').then((response) => {
            console.log(response);
        });
    }

    onProductClick() {
        alert(this.state.UserName);
    }
    render() {
        
        return(
            <div>
                <span>Product List 3 - {this.state.UserName}</span>
                <button onClick = {this.onProductClick.bind(this)} >Product Name</button>    
            </div>
        );
            
    }
}