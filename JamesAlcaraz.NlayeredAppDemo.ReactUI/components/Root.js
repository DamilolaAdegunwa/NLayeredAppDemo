import React from 'react';
import ReactDOM from 'react-dom';
import { Header } from './Header';
import { Footer } from './Footer';
import { SideMenu } from './SideMenu';

export class Root extends React.Component {
    render() {
        return(
            <div>
                <Header />
                <SideMenu />

                <section id="content">
                    <div className="container">
                        <div className="card">
                            <div className="card-body card-padding text-center">
                                {this.props.childeren}
                            </div>
                        </div>
                    </div>
                </section>

                <Footer />
            </div>
            
        );
    }
}