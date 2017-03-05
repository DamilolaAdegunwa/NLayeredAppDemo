import React from 'react';
import ReactDOM from 'react-dom';
import {Router, Route, browserHistory, IndexRoute} from 'react-router'

import { Root } from './Components/Root';
import { Home } from './Components/Home';
import { ProductList } from './components/product/ProductList'

class App extends React.Component {
    render() {
        return(
            <Router history = {browserHistory}>
                <Route path = {"/"} component = {Root}>
                    <IndexRoute component = {Home}/>
                    <Route path = {"home"} component = {Home}/>
                    <Route path = {"products"} component = {ProductList}/>
                </Route>
            </Router>
        );
    }
}

ReactDOM.render(<App />, document.getElementById("app"));