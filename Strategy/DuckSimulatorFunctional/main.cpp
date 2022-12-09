#include <iostream>
#include "CDuck.cpp"

void PlayWithDuck(CDuck& duck)
{
	duck.Display();
	duck.Quack();
	duck.Swim();
	duck.Fly();
	duck.Fly();
	duck.Dance();

	std::cout << std::endl;
}

int main()
{
	CMallardDuck mallardDuck;
	PlayWithDuck(mallardDuck);

	CRedheadDuck redheadDuck;
	PlayWithDuck(redheadDuck);

	CRubberDuck rubberDuck;
	PlayWithDuck(rubberDuck);

	CDecoyDuck decoyDuck;
	PlayWithDuck(decoyDuck);

	decoyDuck.SetFlyBehavior(flyWithWings);
	PlayWithDuck(decoyDuck);
}