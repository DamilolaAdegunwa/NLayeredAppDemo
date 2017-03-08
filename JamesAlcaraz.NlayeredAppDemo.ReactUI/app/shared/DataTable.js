import React from 'react';

export class DataTable extends React.Component {
    constructor(props) {
        super(props);
    }
    generateHeaders() {
        var cols = this.props.cols;  // [{key, value}]

        // generate our header (th) cell components
        return cols.map(function(colData) {
            return <th key={colData.key}>{colData.value}</th>;
        });
    }

    
    generateRows() {
        var cols = this.props.cols,  // [{key, value}]
            data = this.props.data;
        
        return data.map(function(item) {
            // handle the column data within each row

            var objMembers = Object.keys(item);
            var cells = objMembers.map(function(member) {

                // colData.key might be "firstName"
                return <td>{item[member]}</td>;
            });
            return <tr key={item.id}>{cells}</tr>;
        });
    }

    render() {
        var headerComponents = this.generateHeaders(),
            rowComponents = this.generateRows();

        return(
            
            <table id="data-table-basic" className="table table-striped dataTable">
                <thead>{headerComponents}</thead>
                <tbody>{rowComponents}</tbody>
            </table>
        );
            
    }
}