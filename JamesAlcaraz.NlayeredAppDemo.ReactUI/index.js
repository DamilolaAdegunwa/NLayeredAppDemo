import React from 'react';
import ReactDOM from 'react-dom';
import {Router, Route, browserHistory, IndexRoute} from 'react-router'

import { Root } from './Components/Root';
import { Home } from './Components/Home';
import { Login } from './Components/Login';

import { ProductList } from './components/product/ProductList'

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