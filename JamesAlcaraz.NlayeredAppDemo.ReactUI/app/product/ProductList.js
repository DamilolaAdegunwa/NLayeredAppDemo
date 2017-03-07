import React from 'react';
import axios from 'axios';
import { Card } from '../shared/Card';

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
                <div className="table-responsive">
                    <table className="table table-hover">
                        <thead>
                        <tr>
                            <th>#</th>
                            <th>First Name</th>
                            <th>Last Name</th>
                            <th>Username</th>
                            <th>Nickname</th>
                        </tr>
                        </thead>
                        <tbody>
                        <tr>
                            <td>1</td>
                            <td>Alexandra</td>
                            <td>Christopher</td>
                            <td>@makinton</td>
                            <td>Ducky</td>
                        </tr>
                        <tr>
                            <td>2</td>
                            <td>Madeleine</td>
                            <td>Hollaway</td>
                            <td>@hollway</td>
                            <td>Cheese</td>
                        </tr>
                        <tr>
                            <td>3</td>
                            <td>Sebastian</td>
                            <td>Johnston</td>
                            <td>@sebastian</td>
                            <td>Jaycee</td>
                        </tr>
                        <tr>
                            <td>4</td>
                            <td>Mitchell</td>
                            <td>Christin</td>
                            <td>@mitchell4u</td>
                            <td>AdskiDeAnus</td>
                        </tr>
                        <tr>
                            <td>5</td>
                            <td>Elizabeth</td>
                            <td>Belkitt</td>
                            <td>@belkitt</td>
                            <td>Goat</td>
                        </tr>
                        <tr>
                            <td>6</td>
                            <td>Benjamin</td>
                            <td>Parnell</td>
                            <td>@wayne234</td>
                            <td>Pokie</td>
                        </tr>
                        <tr>
                            <td>7</td>
                            <td>Katherine</td>
                            <td>Buckland</td>
                            <td>@anitabelle</td>
                            <td>Wokie</td>
                        </tr>
                        <tr>
                            <td>8</td>
                            <td>Nicholas</td>
                            <td>Walmart</td>
                            <td>@mwalmart</td>
                            <td>Spike</td>
                        </tr>
                        </tbody>
                    </table>
                </div>
            </Card>
        );
            
    }
}