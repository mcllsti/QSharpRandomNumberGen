namespace Quantum.QSharpRandomNumberGen {

    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Intrinsic;
    open Microsoft.Quantum.Measurement;
    open Microsoft.Quantum.Math;
    open Microsoft.Quantum.Convert;

    @EntryPoint()
    operation SampleRandomNumber() : Int 
    {
        let max = 50;
        Message($"Sampling a random number between 0 and {max}: ");

        return SampleRandomNumberInRange(max);
    }

    operation GetQubits () : Result 
    {
        use q = Qubit();   // Allocate a qubit.
        H(q);              // Put the qubit to superposition. It now has a 50% chance of being 0 or 1.

        return MResetZ(q); // Measure the qubit value.
    }

    operation SampleRandomNumberInRange(max : Int) : Int
    {
        mutable bits = new Result[0];
        
        for idxBit in 1..BitSizeI(max) 
        {
            set bits += [GetQubits()];
        }

        let sample = ResultArrayAsInt(bits);

        return sample > max ? 
            SampleRandomNumberInRange(max) | sample;
    }
}
