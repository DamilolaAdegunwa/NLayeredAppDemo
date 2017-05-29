import React from 'react';
import axios from 'axios';
import { Card } from '../shared/Card';
import { DataTable } from '../shared/DataTable'
const baseUrl = 'http://localhost:58010';

export class ProductList extends React.Component {
    constructor() {
        super();
        this.state ={
            products: [],
            columns: []
        }
    }
    
    componentWillMount () {

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
            this.setState({
                products: response.data.items,
                columns: response.data.columns
            });
        });
    }

    onProductClick() {
        //alert(this.state.UserName);
    }
    render() {
        var products = this.state.products,  // [{key, value}]
            columns = this.state.columns
        return(
            <Card cardHeader = {"Product List"}>
                    <div className="table-responsive">
                        <div id="data-table-basic_wrapper" className="dataTables_wrapper">
                            <DataTable cols = {columns} data = {products} />
                        </div>

                    </div>


                
            </Card>
        );
            
    }
}