import React from 'react';
import {Link} from 'react-router';

export class SideMenu extends React.Component {
    
    render() {
        return(
            <aside id="sidebar" className="sidebar c-overflow">
                <div className="s-profile">
                    <a href="" data-ma-action="profile-menu-toggle">
                        <div className="sp-pic">
                            <img src="img/profile-pic.jpg" alt="" />
                        </div>

                        <div className="sp-info">
                            James Alcaraz

                            <i className="zmdi zmdi-caret-down"></i>
                        </div>
                    </a>

                    <ul className="main-menu">
                        <li>
                            <a href=""><i className="zmdi zmdi-account"></i> View Profile</a>
                        </li>
                        <li>
                            <a href=""><i className="zmdi zmdi-input-antenna"></i> Privacy Settings</a>
                        </li>
                        <li>
                            <a href=""><i className="zmdi zmdi-settings"></i> Settings</a>
                        </li>
                        <li>
                            <a href=""><i className="zmdi zmdi-time-restore"></i> Logout</a>
                        </li>
                    </ul>
                </div>

                <ul className="main-menu">
                    <li className="active">
                        <Link to = {'/products'}>
                            <i className="zmdi zmdi-home"></i>Products
                        </Link>
                    </li>
                    <li><a href="typography.html"><i className="zmdi zmdi-format-underlined"></i> Typography</a></li>
                    <li><a href="tables.html"><i className="zmdi zmdi-view-list"></i> Tables</a></li>
                    <li><a href="form-elements.html"><i className="zmdi zmdi-collection-text"></i> Form Elements</a></li>
                    <li><a href="buttons.html"><i className="zmdi zmdi-crop-16-9"></i> Buttons</a></li>
                    <li><a href="icons.html"><i className="zmdi zmdi-airplane"></i>Icons</a></li>
                    <li className="sub-menu">
                        <a href="" data-ma-action="submenu-toggle"><i className="zmdi zmdi-collection-item"></i> Sample Pages</a>
                        <ul>
                            <li><a href="login.html">Login and Sign Up</a></li>
                            <li><a href="lockscreen.html">Lockscreen</a></li>
                            <li><a href="404.html">Error 404</a></li>
                        </ul>
                    </li>
                    <li className="sub-menu">
                        <a href="" data-ma-action="submenu-toggle"><i className="zmdi zmdi-menu"></i> 3 Level Menu</a>

                        <ul>
                            <li><a href="form-elements.html">Level 2 link</a></li>
                            <li className="sub-menu">
                                <a href="" data-ma-action="submenu-toggle">I have children too</a>

                                <ul>
                                    <li><a href="">Level 3 link</a></li>
                                    <li><a href="">Another Level 3 link</a></li>
                                    <li><a href="">Third one</a></li>
                                </ul>
                            </li>
                            <li><a href="">One more 2</a></li>
                        </ul>
                    </li>
                </ul>
            </aside>
        );
            
    }
}