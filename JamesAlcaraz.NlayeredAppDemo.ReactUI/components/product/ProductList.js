import React from 'react';
import axios from 'axios';
import { Card } from '../Card';

const baseUrl = 'http://localhost:58010';

export class ProductList extends React.Component {
    constructor() {
        super();
        this.state ={
            UserName: "John"
        }
    }
    
    componentDidMount() {

        // axios({
        //     method: 'post',
        //     url: baseUrl + '/api/products',
        //     data: {
        //         description: 'Macbook Pro'
        //     }
        // }).then((response) => {
        //     console.log(response);
        // }).catch((err) => {
        //     console.log(err);
        // });

        axios.get(baseUrl + '/api/products').then((response) => {
            console.log(response);
        });
    }

    onProductClick() {
        alert(this.state.UserName);
    }
    render() {
        
        return(
            <Card cardHeader = {"Product List"}>
                <span>Product List 3 - {this.state.UserName}</span>
                <button onClick = {this.onProductClick.bind(this)} >Product Name</button>    
            </Card>
        );
            
    }
}