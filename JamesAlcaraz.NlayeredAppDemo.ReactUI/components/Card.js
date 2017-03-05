import React from 'react';

export class Card extends React.Component {
    
    render() {
        return(
            <div className="card">
                 <div className="card-header ch-alt m-b-20">
                    <h2>{this.props.cardHeader}
                    </h2>
                </div>
                <div className="card-body card-padding">
                    {this.props.children}
                </div>
            </div>
        );
            
    }
}