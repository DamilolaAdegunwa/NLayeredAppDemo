import React from 'react';
import ReactDOM from 'react-dom';
import { Header } from './Components/Header';
import { SideMenu } from './Components/SideMenu';
import {Content} from './Components/Content';
import {Footer} from './Components/Footer';

class App extends React.Component {
    render() {
        return(
            <div>
                <Header />
                <section id="main">
                    <SideMenu />
                    <Content />
                    <Footer />
                </section>
            </div>
        );
            
    }

}

ReactDOM.render(<App />, document.getElementById("app"));