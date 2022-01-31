
import { Route, Routes } from 'react-router-dom'
import { Test } from './Test';
import { AllTests } from './AllTests';
import { NotFound } from './NotFound';
import { About } from './About';
import { Contact } from './Contact';
import { CreateTest } from './CreateTest';
import { RandomTest } from './RandomTest';
import { UpdateTest } from './UpdateTest';
import { Update } from './Update';
import { TestsConstructor } from './TestConstructor';

export const RoutesComponent = () => {
    return <Routes>
            <Route exact path="/" element={<TestsConstructor />} />
            <Route path="/tests" element={<AllTests />} />
            <Route path="/tests/:id" element={<Test />} />
            <Route path="/test-update" element={<Update />} />
            <Route path="/test-update/:id" element={<UpdateTest />} />
            <Route path="/tests-creator" element={<CreateTest />} />
            <Route path="/random-test" element={<RandomTest />} />
            <Route path="/about" element={<About />} />
            <Route path="/contact" element={<Contact />} />
            <Route path="*" element={<NotFound />} />
        </Routes>;
}