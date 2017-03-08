import React from 'react';
import ReactDOM from 'react-dom';
import {Router, Route, browserHistory, IndexRoute} from 'react-router'

import { Root } from './app/layout/Root';
import { Home } from './app/home/Home';
import { Login } from './app/user/Login';

import { ProductList } from './app/product/ProductList'

class App extends React.Component {
    render() {
        return(
            <Router history = {browserHistory}>
                <Route path = {"/"} component = {Root}>
                    <IndexRoute component = {Home}/>
                    <Route path = {"home"} component = {Home}/>
                    <Route path = {"products"} component = {ProductList}/>
                    <Route path = {"login"} component = {Login}/>
                </Route>
            </Router>
        );
    }
}

ReactDOM.render(<App />, document.getElementById("app"));