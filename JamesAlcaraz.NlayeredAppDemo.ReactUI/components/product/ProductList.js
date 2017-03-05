import React from 'react';

export class ProductList extends React.Component {
    constructor() {
        super();
        this.state ={
            UserName: "John"
        }
    }
    render() {
        
        return(
            <span>Product List 3 - {this.state.UserName}</span>
        );
            
    }
}