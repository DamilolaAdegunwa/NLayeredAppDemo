import React from 'react';
import axios from 'axios';

export class ProductList extends React.Component {
    constructor() {
        super();
        this.state ={
            UserName: "John"
        }
    }
    
    componentDidMount() {
        var root = 'https://jsonplaceholder.typicode.com';
        axios.get(root + '/posts/1').then((response) => {
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