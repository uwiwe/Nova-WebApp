import React from 'react'
import { config } from '@fortawesome/fontawesome-svg-core'
import '@fortawesome/fontawesome-svg-core/styles.css'
config.autoAddCss = false
import './globals.scss'
import NavBar from './Components/NavBar/NavBar'
import MainInfo from './MainInfo/page';
import './globals.scss'
import { open_sans } from './fonts'

export default function Page() {
  return (
    <>
    <body>
      <header>
        <NavBar/>
      </header>
    <main className={open_sans.className}>
      <MainInfo/>
    </main>
    </body>
    </>
  );
}
