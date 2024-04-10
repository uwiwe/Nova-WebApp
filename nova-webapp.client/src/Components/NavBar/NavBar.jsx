'use client';

import icon from '../../assets/img/icon.png';
import Image from 'next/image';
import { open_sans } from '../../fonts';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faBars, faXmark } from '@fortawesome/free-solid-svg-icons';
import classNames from 'classnames';

const cn = classNames;


import styles from'./_navbar.scss';
import { useState } from 'react';


export default function NavBar()
{

  const [menu, toggleMenu]= useState('hidden');

  const showMenu = () =>
  {
    (menu === 'hidden') ? toggleMenu('shown'): toggleMenu('hidden'); 
  }

  return (
    <>
    <div className={'menu-options'}>
        <Image
            src={icon}
            alt="nova logo"
            className={cn('web-logo', `web-logo--${menu}`)}
          />
          <div className={'menu-cta-wrapper'}>
            <FontAwesomeIcon icon={faBars} className={cn(`menu-cta-bars--${menu}`)}  onClick={showMenu}/>
            <FontAwesomeIcon icon={faXmark} className={cn(`menu-cta-xmark--${menu}`)}  onClick={showMenu}/>
          </div>
    </div>
        <ul className={cn('menu', `menu--${menu}`, open_sans.className)}>
          <li className={`${menu}`}>Sobre NOVA</li>
          <li className={`${menu}`}>Inscribirse</li>
          <li className={`${menu}`}>Contacto</li>
          <li className={`${menu}`}>Soporte</li>
        </ul>
    </>
  )  
} 