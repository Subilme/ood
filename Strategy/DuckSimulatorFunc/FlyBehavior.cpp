#include "FlyBehavior.h"

FlyBehavior FlyWithWings()
{
	return [flightCount = 0]() mutable -> void {
		flightCount++;
		std::cout << "I'm flying with wings!!! Flights: " << flightCount << std::endl;
	};
}

void FlyNoWay()
{
}