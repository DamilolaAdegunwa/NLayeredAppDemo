import React from "react";

export class Header extends React.Component {

    render() {
        return (
            <header id="header" className="clearfix" data-ma-theme="blue">
                <ul className="h-inner">
                    <li className="hi-trigger ma-trigger" data-ma-action="sidebar-open" data-ma-target="#sidebar">
                        <div className="line-wrap">
                            <div className="line top"></div>
                            <div className="line center"></div>
                            <div className="line bottom"></div>
                        </div>
                    </li>

                    <li className="hi-logo hidden-xs">
                        <a href="index.html">Material Admin</a>
                    </li>

                    <li className="pull-right">
                        <ul className="hi-menu">

                            <li data-ma-action="search-open">
                                <a href=""><i className="him-icon zmdi zmdi-search"></i></a>
                            </li>

                            <li className="dropdown">
                                <a data-toggle="dropdown" href=""><i className="him-icon zmdi zmdi-more-vert"></i></a>
                                <ul className="dropdown-menu pull-right">
                                    <li className="hidden-xs">
                                        <a data-ma-action="fullscreen" href="">Toggle Fullscreen</a>
                                    </li>
                                    <li>
                                        <a href="">Privacy Settings</a>
                                    </li>
                                    <li>
                                        <a href="">Other Settings</a>
                                    </li>
                                </ul>
                            </li>
                        </ul>
                    </li>
                </ul>

                <div className="h-search-wrap">
                    <div className="hsw-inner">
                        <i className="hsw-close zmdi zmdi-arrow-left" data-ma-action="search-close"></i>
                        <input type="text" />
                    </div>
                </div>

            </header>
            
        );

    }
}