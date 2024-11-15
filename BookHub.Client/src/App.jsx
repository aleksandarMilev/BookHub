import { Route, Routes } from "react-router-dom"

import AuthenticatedRoute from './components/common/authenticated-route/AuthenticatedRoute'
import { routes } from "./common/constants/api"
import { UserContextProvider } from "./contexts/userContext"

import Header from './components/common/header/Header'
import Footer from './components/common/footer/Footer'
import Home from './components/home/Home'

import Login from './components/identity/login/Login'
import Register from './components/identity/register/Register'
import Logout from './components/identity/logout/Logout'

import BookList from "./components/book/book-list/BookList"
import BookDetails from "./components/book/book-details/BookDetails"
import CreateBook from './components/book/create-book/CreateBook'
import EditBook from './components/book/edit-book/EditBook'

import AuthorDetails from "./components/author/author-details/AuthorDetails"
import CreateAuthor from "./components/author/create-author/CreateAuthor"
import EditAuthor from "./components/author/edit-author/EditAuthor"

export default function App(){
    return(
        <UserContextProvider>
            <Header />
            <Routes>
                <Route path={routes.home} element={<Home />} />

                <Route path={routes.login} element={<Login />} />
                <Route path={routes.register} element={<Register />} />
                <Route path={routes.logout} element={<Logout />} />

                <Route path={routes.books} element={<AuthenticatedRoute element={<BookList />} />} />
                <Route path={routes.books + '/:id'} element={<AuthenticatedRoute element={<BookDetails />} />} />
                <Route path={routes.createBook} element={<AuthenticatedRoute element={<CreateBook />} />} />
                <Route path={routes.editBook + '/:id'} element={<AuthenticatedRoute element={<EditBook />} />} />

                <Route path={routes.author + '/:id'} element={<AuthenticatedRoute element={<AuthorDetails />} />} />
                <Route path={routes.createAuthor} element={<AuthenticatedRoute element={<CreateAuthor />} />} />
                <Route path={routes.editAuthor + '/:id'} element={<AuthenticatedRoute element={<EditAuthor />} />} />
            </Routes>
            <Footer /> 
        </UserContextProvider>
    )
}