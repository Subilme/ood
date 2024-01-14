#pragma once

#include "DanceBehavior.h"
#include "FlyBehavior.h"
#include "QuackBehavior.h"

class CDuck
{
public:
	CDuck(QuackBehavior&& quackBehavior, FlyBehavior&& flyBehavior, DanceBehavior&& danceBehavior)
		: m_quackBehavior(std::move(quackBehavior)),
		m_flyBehavior(std::move(flyBehavior)),
		m_danceBehavior(std::move(danceBehavior))
	{
	}

	void Quack()
	{
		m_quackBehavior();
	}

	void Fly()
	{
		m_flyBehavior();
	}
	
	void Dance()
	{
		m_danceBehavior();
	}

	void Swim()
	{
		std::cout << "I`m swimming" << std::endl;
	}

	void SetFlyBehavior(FlyBehavior&& flyBehavior)
	{
		m_flyBehavior = std::move(flyBehavior);
	}

	virtual void Display() const = 0;

	virtual ~CDuck() = default;

private:
	QuackBehavior m_quackBehavior;
	FlyBehavior m_flyBehavior;
	DanceBehavior m_danceBehavior;
};

class CDecoyDuck : public CDuck
{
public:
	CDecoyDuck()
		: CDuck(MuteQuack, FlyNoWay, DanceNoWay)
	{
	}

	void Display() const
	{
		std::cout << "I'm a decoy duck" << std::endl;
	}
};

class CMallardDuck : public CDuck
{
public:
	CMallardDuck()
		: CDuck(QuackQuack, FlyWithWings(), DanceWaltz)
	{
	}

	void Display() const
	{
		std::cout << "I'm a mallard duck" << std::endl;
	}
};

class CModelDuck : public CDuck
{
public:
	CModelDuck()
		: CDuck(QuackQuack, FlyNoWay, DanceNoWay)
	{
	}

	void Display() const
	{
		std::cout << "I'm a model duck" << std::endl;
	}
};

class CRedheadDuck : public CDuck
{
public:
	CRedheadDuck()
		: CDuck(QuackQuack,FlyWithWings(), DanceMenuet)
	{
	}

	void Display() const
	{
		std::cout << "I'm a redhead duck" << std::endl;
	}
};

class CRubberDuck : public CDuck
{
public:
	CRubberDuck()
		: CDuck(Squeak, FlyNoWay, DanceNoWay)
	{
	}

	void Display() const
	{
		std::cout << "I`m rubber duck" << std::endl;
	}
};