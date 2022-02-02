
import { Route, Routes } from 'react-router-dom'
import { Test } from '../Test';
import { AllTests } from './AllTests';
import { NotFound } from './NotFound';
import { About } from './About';
import { Contact } from './Contact';
import { CreateTest } from '../CreateTest';
import { RandomTest } from './RandomTest';
import { UpdateTest } from '../UpdateTest';
import { Update } from './Update';
import { TestsConstructor } from '../TestConstructor';
import { Register } from './Register';
import { Login } from './Login';
import { Logout } from './Logout';
import { Result } from '../Result';

export const RoutesComponent = () => {
    return <Routes>
        <Route exact path="/"  element={<AllTests />} />
        <Route path="/test-constructor" element={<TestsConstructor />} />
        <Route path="/tests"  element={<AllTests />} />
        <Route path="/tests/:id" element={<Test />} />
        <Route path="/test-update" element={<Update />} />
        <Route path="/test-update/:id" element={<UpdateTest />} />
        <Route path="/tests-creator" element={<CreateTest />} />
        <Route path="/random-test" element={<RandomTest />} />
        <Route path="/about" element={<About />} />
        <Route path="/contact" element={<Contact />} />
        <Route path="/person" element={<Result />} />
        <Route path="/login" element={<Login />} />
        <Route path="/Logout" element={<Logout />} />
        <Route path="/register" element={<Register />} />
        <Route path="*" element={<NotFound />} />
    </Routes>;
}