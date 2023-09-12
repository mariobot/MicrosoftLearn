import { useState } from "react";

export function Counter() {
    const [counter, setCounter] = useState(0)

    return (
        <>
            <div class="text-center">
                <span class="text-white text-xl mr-4">Counter: {counter}</span>
                <button class="border px-4 py-2 text-xl" onClick={() => setCounter(counter => counter + 1)}>+</button>
                <button class="border px-4 py-2 text-xl" onClick={() => setCounter(counter => counter - 1)}>-</button>
            </div>
        </>
    )
}